using UnityEngine;

namespace UIBuildings
{
    public class BuildingSelector : MonoBehaviour
    {
        [SerializeField] private BuildingPanel _buildingPanel;

        public void Init()
        {
            _buildingPanel.Show();
        }
    }
}