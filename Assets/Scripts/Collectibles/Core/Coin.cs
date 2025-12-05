using TinyRPG.Collectible.Core;
using UnityEngine;
public class Coin : MonoBehaviour, ICollectible
{
    [SerializeField] private int value;

    public void Collect(CollectibleManager c)
    {
        c.AddCoins(value);
    }

}
