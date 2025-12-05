using TinyRPG.Collectibles.Data;
using UnityEngine;
namespace TinyRPG.Collectible.Core
{
    public interface ICollectible
    {
        void Collect(CollectibleManager collectibleManager);
    }
}