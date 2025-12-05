using System.Collections;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    [SerializeField] private PlayerInputHandler _playerInputHandler;
    [SerializeField] private HealthController _healthController;
    [SerializeField] private PlayerMoveController _playerMoveController;

    [SerializeField] private float _AttackCoolDown;
    [SerializeField] private float _ParryCoolDown;

    private Coroutine _currentCoolDownCoroutine = null;

    [SerializeField] private GameObject _AttackCollider;

    private bool _canAttack = true;
    private bool _canParry = true;

    private bool isParrying = false;
    [SerializeField] private float _damage;

    private void Start()
    {
        _healthController.OnHitDetected += ReceiveAttack;
        _playerInputHandler.OnAttack += Attack;
        _playerInputHandler.OnParry += Parry;

        _AttackCollider.TryGetComponent(out AttackBoxController attackBoxController);
        if (attackBoxController != null)
            attackBoxController.Damage = _damage;
    }
    private void OnDestroy()
    {
        _playerInputHandler.OnAttack -= Attack;
        _playerInputHandler.OnParry -= Parry;
        _healthController.OnHitDetected -= ReceiveAttack;
    }

    public void Attack()
    {
        if (_canAttack)
        {
            _playerMoveController.CanMove = false;
            _AttackCollider.SetActive(true);
            _currentCoolDownCoroutine = StartCoroutine(WaitForAttackCooldown());
        }
    }


    public void Parry()
    {
        if (_canParry)
        {
            _playerMoveController.CanMove = false;
            _canAttack = false;
            _canParry = false;
            isParrying = true;
            _currentCoolDownCoroutine = StartCoroutine(WaitForParryCooldown());
        }
    }

    /// <summary>
    /// Sert a calculer les degats reduits avant d'appeler le take damage du composant de vie
    /// </summary>
    /// <param name="damage"></param>
    public void ReceiveAttack(float damage)
    {
        if (!isParrying)
        {
            _healthController.TakeDamage(damage);
        }
    }

    private IEnumerator WaitForAttackCooldown()
    {
        yield return new WaitForSeconds(_AttackCoolDown);
        _canAttack = true;
        _AttackCollider.SetActive(false);
        _currentCoolDownCoroutine = null;
        _playerMoveController.CanMove = true;
    }

    private IEnumerator WaitForParryCooldown()
    {
        yield return new WaitForSeconds(_ParryCoolDown);
        _canParry = true;
        isParrying = false;
        _currentCoolDownCoroutine = null;
        _canAttack = true;
        _playerMoveController.CanMove = true;
    }
}
