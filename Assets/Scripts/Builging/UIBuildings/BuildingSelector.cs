﻿using UnityEngine;

namespace Buildings
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