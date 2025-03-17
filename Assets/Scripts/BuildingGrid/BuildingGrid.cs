using Buildings;
using Data;
using UnityEngine;
using UnityEngine.UIElements;

namespace Grid
{
    public class BuildingGrid : MonoBehaviour
    {
        [SerializeField] private BuildingContent _buildingContent;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Deleter _deleter;

        public Building[,] _gridArray;

        private BuildingsData _buildingData;
        private IDataSaver _dataSaver;

        [field: SerializeField] public Vector2Int GridSize { get; private set; }

        public Building AvailableBuilding { get; private set; }


        private void OnEnable()
        {
            _deleter.Deleted += Delete;
        }

        private void OnDisable()
        {
            _deleter.Deleted -= Delete;
        }

        public void Init(IDataSaver dataSaver, BuildingsData buildingsData)
        {
            _gridArray = new Building[GridSize.x, GridSize.y];
            _buildingData = buildingsData;
            _dataSaver = dataSaver;
        }

        public void LoadBuildings()
        {
            foreach (var buildingData in _buildingData.BuildingSaveData)
            {
                Building buildingPrefab = GetBuildingPrefabByType(buildingData.BuildingType);
                Building building = Instantiate(buildingPrefab, new Vector3(buildingData.Position.x, 0, buildingData.Position.y), Quaternion.identity);

                PlaceBuildingOnGrid(building, buildingData.Position);
            }
        }

        public void SetBuilding(Building buildingPrefab)
        {
            AvailableBuilding = buildingPrefab;
        }

        public bool IsPlaceTaken(int placeX, int placeY)
        {
            for (int x = 0; x < AvailableBuilding.Size.x; x++)
            {
                for (int y = 0; y < AvailableBuilding.Size.y; y++)
                {
                    if (_gridArray[placeX + x, placeY + y] != null)
                        return true;
                }
            }

            return false;
        }

        public void PlaceAvailableBuilding(int placeX, int placeY)
        {
            AvailableBuilding.SetBaseRenderer();
            var building = Instantiate(AvailableBuilding, AvailableBuilding.transform.position, AvailableBuilding.transform.rotation);

            SetBuildingInGridArray(AvailableBuilding, building, placeX, placeY);

            _buildingData.BuiltBuildings(building.BuildingType, new Vector2Int(placeX, placeY));
            _dataSaver.Save();
        }

        private void Delete(Building building)
        {
            int posX = SetPosition(building.transform.position.x);
            int posY = SetPosition(building.transform.position.z);

            SetBuildingInGridArray(building, null, posX, posY);

            if (building != null)
            {
                _buildingData.RemoveBuildings(building.BuildingType, new Vector2Int(posX, posY));
                Destroy(building.gameObject);
            }

            _dataSaver.Save();
        }

        private int SetPosition(float worldPosition)
        {
            return Mathf.RoundToInt(worldPosition);
        }

        private Building GetBuildingPrefabByType(BuildingType buildingType)
        {
            return _buildingContent.GetBuildingPrefab(buildingType);
        }

        private void PlaceBuildingOnGrid(Building building, Vector2Int position)
        {
            SetBuildingInGridArray(building, building, position.x, position.y);
        }

        private void SetBuildingInGridArray(Building building, Building VariableRightSide, int xPosition, int yPosition)
        {
            for (int x = 0; x < building.Size.x; x++)
            {
                for (int y = 0; y < building.Size.y; y++)
                {
                    _gridArray[xPosition + x, yPosition + y] = VariableRightSide;
                }
            }
        }

        [ExecuteInEditMode]
        private void OnDrawGizmos()
        {
            int evenNubmer = 2;
            float yPosition = 0;
            float cellSize = 1;

            for (int x = 0; x < GridSize.x; x++)
            {
                for (int y = 0; y < GridSize.y; y++)
                {
                    if ((x + y) % evenNubmer == 0)
                        Gizmos.color = new Color(0.88f, 0f, 1f, 0.1f);
                    else
                        Gizmos.color = new Color(1f, 0.68f, 0f, 0.1f);

                    Gizmos.DrawCube(transform.position + new Vector3(x, yPosition, y), new Vector3(cellSize, 0.1f, cellSize));
                }
            }
        }
    }
}