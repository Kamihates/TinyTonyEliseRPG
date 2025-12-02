using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(PlayerMoveController))]
[RequireComponent(typeof(PlayerAnimationController))]

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerMoveController _playerMoveController;
    private PlayerAnimationController _playerAnimationController;

    private void Start()
    {
        TryGetComponent(out _playerMoveController);
        TryGetComponent(out _playerAnimationController);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _playerMoveController.Move(context.ReadValue<Vector2>());
        _playerAnimationController.Walk(context.ReadValue<Vector2>() != Vector2.zero);
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _playerMoveController.Sprint(true);
            _playerAnimationController.Run(true);

        }
        else if (context.canceled)
        {
            _playerMoveController.Sprint(false);
            _playerAnimationController.Run(false);
        }
    }
}
