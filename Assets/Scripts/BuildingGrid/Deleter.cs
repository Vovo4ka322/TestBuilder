using Buildings;
using InputSystem;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Grid
{
    public class Deleter : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private Button _removerButton;

        private bool _canDelete = false;

        public event Action<Building> Deleted;

        private void OnEnable()
        {
            _removerButton.onClick.AddListener(SetDeleteTrue);
        }

        private void Update()
        {
            UseRaycast();
        }

        private void OnDisable()
        {
            _removerButton?.onClick.RemoveListener(SetDeleteTrue);
        }

        private void UseRaycast()
        {
            if (_playerController.Select && _canDelete)
            {
                Ray ray = Camera.main.ScreenPointToRay(_playerController.Position);

                if (Physics.Raycast(ray, out RaycastHit raycastHit))
                {
                    if (raycastHit.collider.TryGetComponent(out Building component))
                    {
                        _canDelete = false;
                        Deleted?.Invoke(component);
                    }
                }
            }
        }

        private void SetDeleteTrue() => _canDelete = true;
    }
}