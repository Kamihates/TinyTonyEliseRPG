using TinyRPG.Collectible.Core;
using UnityEngine;
using TinyRPG.Collectibles.Data;
using System.Collections;

namespace TinyRPG.Collectibles.Core
{

    public class Collectible : MonoBehaviour, ICollectible
    {
        private CollectibleData collectibleData;
        private Collider col;
        private PlayerMoveController player;
        //private HealthController healthController;

        private void Awake()
        {
            col = GetComponent<Collider>();
            //healthController = player.GetComponent<HealthController>();

            if (col != null && col.isTrigger == false)
                col.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            player = other.GetComponentInParent<PlayerMoveController>();
            if (player != null)
            {
                Collect(player);
                Destroy(gameObject);
            }
        }

        public void Collect(PlayerMoveController player)
        {
            switch(collectibleData.collectibleType)
            {
                case CollectibleData.CollectibleType.Coin:
                    //player.AddGold(collectibleData.goldValue);
                    break;
                case CollectibleData.CollectibleType.HealthPotion:
                    //healthController.AddLife(collectibleData.healthRestoreAmount);
                    break;
                case CollectibleData.CollectibleType.InvincibilityPotion:
                    //StartCoroutine(ResetInvicibility(healthController, collectibleData.invincibilityDuration));
                    break;
            }
        }

/*        private IEnumerator ResetInvicibility(HealthController health, float duration)
        {
            health.isInvincible = true;
            yield return new WaitForSeconds(duration);
            health.isInvincible = false;
        }*/
    }
}
