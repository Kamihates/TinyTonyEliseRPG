using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveController : MonoBehaviour
{
    private Rigidbody _playerRb;
    private Vector2 _moveDirection;
    private bool _isRunning = false;

    [SerializeField] private float _moveSpeed = 1;
    private float _currentSpeed;


    private void Awake()
    {
        TryGetComponent(out _playerRb);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        _moveDirection = Quaternion.Euler(0, 0, 45) * context.ReadValue<Vector2>(); // on multiplie par 45 sur laxe Z comme c'est en isometric
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _isRunning = true;
        }
        else if (context.canceled)
        {
            _isRunning = false;
        }
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(_moveDirection.x, 0, _moveDirection.y);

        if (_isRunning)
        {
            _currentSpeed = _moveSpeed * 2;
        }
        else
        {
            _currentSpeed = _moveSpeed;
        }

        
        _playerRb.linearVelocity = move * _currentSpeed;
    }
}
