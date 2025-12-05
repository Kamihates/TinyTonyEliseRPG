using UnityEngine;
using UnityEngine.UI;

public class HealthUIController : MonoBehaviour
{
    [SerializeField] private HealthController healthController;
    [SerializeField] private Slider healthSlider;

    private void Start()
    {
        healthController.OnDamageUpdate += UpdateHealthUI;
        healthController.OnLifeUpdate += UpdateHealthUI;

        healthSlider.maxValue = healthController.MaxHealth;
        healthSlider.value = healthController.CurrentHealth;
    }

    private void OnDestroy()
    {
        healthController.OnDamageUpdate -= UpdateHealthUI;
    }

    public void UpdateHealthUI(float  health)
    {
        healthSlider.value = health;
    }
}
