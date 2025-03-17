using Buildings;
using UnityEngine;

namespace UIBuildings
{
    public class BuildingPanel : MonoBehaviour
    {
        [SerializeField] private BuildingViewerFactory _buildingViewerFactory;
        [SerializeField] private Transform _parent;
        [SerializeField] private BuildingContent _buildingContent;

        public void Show()
        {
            foreach (Building building in _buildingContent.Buildings)
            {
                BuildingItem buildingItemViewer = _buildingViewerFactory.Get(building, _parent);
            }
        }
    }
}