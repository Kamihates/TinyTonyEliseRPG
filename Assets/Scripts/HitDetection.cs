using UnityEngine;

public class HitDetection : MonoBehaviour
{
    [SerializeField] private HealthController healthComponent;
    

    public void HitDetected(float damage)
    {
        healthComponent.OnHitDetected?.Invoke(damage);

        Debug.Log("degat :" +  damage);
    }
}
