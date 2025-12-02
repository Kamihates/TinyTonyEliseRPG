using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private PlayerInputHandler _playerInputHandler;

    private Rigidbody _playerRb;
    private Vector2 _moveDirection;

    // vitesse de déplacement
    [SerializeField] private float _moveSpeed = 1;
    private float _currentSpeed;

    private void Awake()
    {
        TryGetComponent(out _playerRb);
        _currentSpeed = _moveSpeed;
    }

    private void Start()
    {
        // abonnement
        _playerInputHandler.OnMove += Move;
        _playerInputHandler.OnSprint += Sprint;
    }

    private void OnDestroy()
    {
        _playerInputHandler.OnMove -= Move;
        _playerInputHandler.OnSprint -= Sprint;
    }

    public void Move(Vector2 moveInput)
    {
        _moveDirection = Quaternion.Euler(0, 0, 45) * moveInput; // on multiplie par 45 sur laxe Z comme c'est en isometric
    }

    public void Sprint(bool isRunning)
    {
        _currentSpeed = isRunning ? _moveSpeed * 2 : _moveSpeed;
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(_moveDirection.x * _currentSpeed,0, _moveDirection.y * _currentSpeed);
        _playerRb.linearVelocity = move;

        if (_playerRb.linearVelocity != Vector3.zero)
        {
            Vector3 rotationMove = new Vector3(_playerRb.linearVelocity.x, 0, _playerRb.linearVelocity.z);
            Quaternion targetRotation = Quaternion.LookRotation(rotationMove.normalized, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.3f);
        }
    }
}
