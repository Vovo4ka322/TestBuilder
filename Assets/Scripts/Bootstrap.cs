using Data;
using Grid;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private PlayerController _controller;
    [SerializeField] private BuildingGrid _buildingGrid;
    [SerializeField] private BuildingSelector _buildingSelector;

    private IDataSaver _iDataSaver;
    private IPersistentData _persistentPlayerData;

    private void Awake()
    {
        InitializeData();
        Init();
        _buildingGrid.LoadBuildings();
    }

    private void Init()
    {
        _buildingGrid.Init(_iDataSaver, _persistentPlayerData.BuildingData);
        _buildingSelector.Init();
    }

    private void InitializeData()
    {
        _persistentPlayerData = new PersistentData();
        _iDataSaver = new IDataLocalSaver(_persistentPlayerData);

        LoadDataOrInit();
    }

    private void LoadDataOrInit()
    {
        if (_iDataSaver.TryLoad() == false)
        {
            _persistentPlayerData.BuildingData = new();
        }
    }
}
