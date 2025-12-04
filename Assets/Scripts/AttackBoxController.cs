using UnityEngine;

public class AttackBoxController : MonoBehaviour
{
    private float _damage;
    public float Damage { get => _damage; set => _damage = value; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out HitDetection hitDetection))
            hitDetection.HitDetected(_damage);
    }
}
