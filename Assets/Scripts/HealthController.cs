using System;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public Action<float> OnDamageUpdate;
    public Action<float> OnLifeUpdate;

    public Action<float> OnHitDetected;
    public Action OnDeath;

    [SerializeField] private float _maxHealth;
    public float MaxHealth => _maxHealth;

    private float _currentHealth;
    public float CurrentHealth => _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }
    public void TakeDamage(float damage)
    {
        if (damage <= 0) return;

        _currentHealth -= damage;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

        OnDamageUpdate?.Invoke(CurrentHealth);

        if (_currentHealth <= 0 )
        {
            OnDeath?.Invoke();
        }
    }

    public void AddLife(float health)
    {
        _currentHealth += health;
        OnLifeUpdate?.Invoke(CurrentHealth);
    }

}
