using Buildings;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [System.Serializable]
    public class BuildingsData
    {
        private List<BuildingSaveData> _buildingSaveData;

        public BuildingsData()
        {
            _buildingSaveData = new List<BuildingSaveData>();
        }

        [JsonConstructor]
        public BuildingsData(List<BuildingSaveData> buildingSaveData)
        {
            _buildingSaveData = buildingSaveData;
        }

        public IReadOnlyList<BuildingSaveData> BuildingSaveData => _buildingSaveData;

        public void BuiltBuildings(BuildingType buildingType, Vector2Int position)
        {
            _buildingSaveData.Add(new BuildingSaveData(buildingType, position));
        }

        public void RemoveBuildings(BuildingType buildingType, Vector2Int position)
        {
            BuildingSaveData buildingToRemove = _buildingSaveData.Find(b => b.BuildingType == buildingType && b.Position == position);

            if (buildingToRemove != null)
            {
                _buildingSaveData.Remove(buildingToRemove);
            }
        }
    }
}