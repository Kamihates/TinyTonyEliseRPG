using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public event Action<Vector2> OnMove;
    public event Action<bool> OnSprint;
    public event Action OnAttack;
    public event Action OnParry;

    private bool _canMove = true;
    public bool CanMove { get => _canMove; set => _canMove = value; }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (_canMove) 
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

    public void Attack(InputAction.CallbackContext context)
    {
        OnAttack?.Invoke();
    }

    public void Parry(InputAction.CallbackContext context)
    {
        OnParry?.Invoke();
    }
}
