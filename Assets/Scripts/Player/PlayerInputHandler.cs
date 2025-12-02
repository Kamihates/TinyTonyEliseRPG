using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public event Action<Vector2> OnMove;
    public event Action<bool> OnSprint;

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        OnMove?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnSprintInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OnSprint?.Invoke(true);

        }
        else if (context.canceled)
        {
            OnSprint?.Invoke(false);
        }
    }
}
