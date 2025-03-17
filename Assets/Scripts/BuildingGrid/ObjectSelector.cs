using Buildings;
using InputSystem;
using UnityEngine;

namespace Grid
{
    public class ObjectSelector : MonoBehaviour
    {
        [SerializeField] private PlayerController _controller;
        [SerializeField] private BuildingGrid _buildingGrid;

        private Building _building;

        private void Update()
        {
           UseRaycast();
        }

        private void UseRaycast()
        {
            if (_building != null)
            {
                Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
                Ray ray = Camera.main.ScreenPointToRay(_controller.Position);

                if (groundPlane.Raycast(ray, out float position))
                {
                    Vector3 worldPosition = ray.GetPoint(position);

                    int x = SetPosition(worldPosition.x);
                    int y = SetPosition(worldPosition.z);

                    bool available = true;

                    if (x < 0 || x > _buildingGrid.GridSize.x - _building.Size.x)
                        available = false;

                    if (y < 0 || y > _buildingGrid.GridSize.y - _building.Size.y)
                        available = false;

                    if (available && _buildingGrid.IsPlaceTaken(x, y))
                        available = false;

                    _building.ChangePositionAndRenderer(x, y, available);

                    if (available && _controller.Select)
                        _buildingGrid.PlaceAvailableBuilding(x, y);

                    if (_controller.Unselect)
                        Destroy(_building.gameObject);
                }
            }
        }

        public void SetBuilding(Building building)
        {
            _building = building;
            _buildingGrid.SetBuilding(building);
        }

        private int SetPosition(float worldPosition)
        {
            return Mathf.RoundToInt(worldPosition);
        }
    }
}