using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    [SerializeField] private PlayerInputHandler _playerInputHandler;

    private void Start()
    {
        _playerInputHandler.OnAttack += Attack;
        _playerInputHandler.OnParry += Parry;
    }
    public void Attack()
    {
        
    }

    public void Parry()
    {

    }

    public void ReceiveAttack(float damage)
    {
        
    }
}
