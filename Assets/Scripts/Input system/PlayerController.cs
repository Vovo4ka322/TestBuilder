using UnityEngine;

namespace InputSystem
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerInput _playerInput;

        public Vector2 Position { get; private set; }

        public bool Select { get; private set; }

        public bool Unselect { get; private set; }

        public void Awake()
        {
            _playerInput = new();
        }

        private void OnEnable()
        {
            _playerInput.Enable();
            _playerInput.Player.MousePosition.performed += OnLookPerfomed;
            _playerInput.Player.MousePosition.canceled += OnLookPerfomed;
            _playerInput.Player.Select.performed += OnRightClicked;
            _playerInput.Player.Select.canceled += OnRightClicked;
            _playerInput.Player.Unselect.performed += OnLeftClicked;
            _playerInput.Player.Unselect.canceled += OnLeftClicked;
        }

        private void OnDisable()
        {
            _playerInput.Disable();
            _playerInput.Player.Select.performed -= OnRightClicked;
            _playerInput.Player.Select.canceled -= OnRightClicked;
            _playerInput.Player.MousePosition.performed -= OnLookPerfomed;
            _playerInput.Player.MousePosition.canceled -= OnLookPerfomed;
            _playerInput.Player.Unselect.performed -= OnLeftClicked;
            _playerInput.Player.Unselect.canceled -= OnLeftClicked;
        }

        private void OnLookPerfomed(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            Position = context.ReadValue<Vector2>();
        }

        private void OnRightClicked(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            Select = context.ReadValueAsButton();
        }

        private void OnLeftClicked(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            Unselect = context.ReadValueAsButton();
        }
    }
}