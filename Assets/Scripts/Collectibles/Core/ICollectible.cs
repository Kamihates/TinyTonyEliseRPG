using UnityEngine;
namespace TinyRPG.Collectible.Core
{
    public interface ICollectible
    {
        void Collect(PlayerMoveController player);
    }
}