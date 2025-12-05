using TinyRPG.Collectible.Core;
using UnityEngine;

public class HealthPotion : MonoBehaviour, ICollectible
{

    [SerializeField] private float value;

    public void Collect(CollectibleManager c)
    {
        c.AddLife(value);
    }
}
