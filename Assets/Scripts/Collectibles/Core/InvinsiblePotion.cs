using TinyRPG.Collectible.Core;
using UnityEngine;

public class InvinsiblePotion : MonoBehaviour, ICollectible
{
    [SerializeField] private float time;

    public void Collect(CollectibleManager c)
    {
        c.SetInvincibility(time);
    }
}
