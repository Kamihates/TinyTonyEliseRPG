using UnityEngine;

public class AttackBoxController : MonoBehaviour
{
    private float _damage;
    public float Damage { get => _damage; set => _damage = value; }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<HitDetection>()?.HitDetected(_damage);
    }
}
