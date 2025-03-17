using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingContent", menuName = "BuildingContent")]
public class BuildingContent : ScriptableObject
{
    [SerializeField] private List<Building> _buildings;

    public IReadOnlyList<Building> Buildings => _buildings;

    public Building GetBuildingPrefab(BuildingType buildingType)
    {
        return _buildings.Find(b => b.BuildingType == buildingType);
    }
}
