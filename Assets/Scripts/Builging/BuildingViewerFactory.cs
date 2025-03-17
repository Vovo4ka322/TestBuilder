using UnityEngine;

public class BuildingViewerFactory : MonoBehaviour
{
    [SerializeField] private BuildingItem _buildingItemViewerPrefab;
    [SerializeField] private Placer _placer;

    public BuildingItem Get(Building building, Transform parent)
    {
        BuildingItem viewer = Instantiate(_buildingItemViewerPrefab, parent);
        viewer.Init(building, _placer);

        return viewer;
    }
}
