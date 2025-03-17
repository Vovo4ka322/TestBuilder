using UnityEngine;

namespace Data
{
    [System.Serializable]
    public class BuildingSaveData
    {
        public BuildingType BuildingType;
        public Vector2Int Position;

        public BuildingSaveData(BuildingType buildingType, Vector2Int position)
        {
            BuildingType = buildingType;
            Position = position;
        }
    }
}