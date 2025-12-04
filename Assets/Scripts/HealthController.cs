using System;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public Action<float> OnHitDetected;
    public Action OnDeath;

    [SerializeField] private float _maxHealth;
    private float _currentHealth;

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

        if (_currentHealth <= 0 )
        {
            OnDeath?.Invoke();
        }
    }

}
