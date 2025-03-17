using UnityEngine;
using UnityEngine.UI;
using Buildings;

namespace Grid
{
    public class Placer : MonoBehaviour
    {
        [SerializeField] private Button _placeSetterButton;
        [SerializeField] private ObjectSelector _objectSelector;
        [SerializeField] private Transform _spawnPoint;

        private Building _building;

        private void OnEnable()
        {
            _placeSetterButton.onClick.AddListener(() => Build(_building));
        }

        private void OnDisable()
        {
            _placeSetterButton.onClick.RemoveListener(() => Build(_building));
        }

        public void SetBuilding(Building building)
        {
            if (_building != null)
                Destroy(_building.gameObject);

            _building = Instantiate(building, _spawnPoint.position, Quaternion.identity);
        }

        private void Build(Building building)
        {
            _objectSelector.SetBuilding(building);
        }
    }
}