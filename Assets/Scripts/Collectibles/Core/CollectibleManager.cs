using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    private int coinsCount = 0;
    [SerializeField] private HealthController healthController;
    [SerializeField] private PlayerCombatController combatController;
    [SerializeField] private CoinsUI coinsUI;

    public void AddCoins(int value)
    {
        Debug.Log("coin add");
        coinsCount += value;
        coinsUI.UpdateUI(coinsCount);
    }

    public void AddLife(float value)
    {
        healthController.AddLife(value);
    }

    public void SetInvincibility(float time)
    {
        combatController.IsInvincible(time);
    }
}
