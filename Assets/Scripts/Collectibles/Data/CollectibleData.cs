using NaughtyAttributes;
using UnityEngine;

namespace TinyRPG.Collectibles.Data
{
    [CreateAssetMenu(fileName = "New Collectible Data", menuName = "TinyRPG/Items/Collectible Data")]
    public class CollectibleData : ScriptableObject
    {
        public enum CollectibleType
        {
            Coin,
            HealthPotion,
            InvincibilityPotion
        }

        public CollectibleType collectibleType;

        [HorizontalLine(color: EColor.Black)]
        [Foldout("Potions")]
        public float healthRestoreAmount = 20f;
        [Foldout("Potions")]
        public float invincibilityDuration = 5f;

        [HorizontalLine(color: EColor.Black)]
        [Foldout("Common")]
        public int coinValue = 1;


    }
}
