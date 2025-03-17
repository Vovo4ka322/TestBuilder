using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Grid;
using Buildings;

namespace UIBuildings
{
    public class BuildingItem : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _textMash;

        private Building _building;
        private Placer _placer;

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClicked);
        }

        public void Init(Building building, Placer placer)
        {
            _building = building;
            _placer = placer;

            _textMash.text = building.name;
            _button.onClick.AddListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            _placer.SetBuilding(_building);
        }
    }
}