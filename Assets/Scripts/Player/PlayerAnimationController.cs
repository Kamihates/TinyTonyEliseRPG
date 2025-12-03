using UnityEngine;


public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerInputHandler _playerInputHandler;

    private void Start()
    {
        // abonnement
        _playerInputHandler.OnMove += SetWalkAnimation;
        _playerInputHandler.OnSprint += SetRunAnimation;
        _playerInputHandler.OnAttack += SetAttackAnimation;
        _playerInputHandler.OnParry += SetParryAnimation;
    }

    private void OnDestroy()
    {
        _playerInputHandler.OnMove -= SetWalkAnimation;
        _playerInputHandler.OnSprint -= SetRunAnimation;
        _playerInputHandler.OnAttack -= SetAttackAnimation;
        _playerInputHandler.OnParry -= SetParryAnimation;
    }

    public void SetWalkAnimation(Vector2 moveInputDirection)
    {
        _animator.SetBool("isWalking", moveInputDirection != Vector2.zero);
    }

    public void SetRunAnimation(bool isRunning)
    {
        _animator.SetBool("isRunning", isRunning);
    }

    public void SetAttackAnimation()
    {
        _animator.SetTrigger("Attack");
    }
    public void SetParryAnimation()
    {
        _animator.SetTrigger("Parry");
    }
}
