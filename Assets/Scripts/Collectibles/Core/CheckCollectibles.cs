using TinyRPG.Collectible.Core;
using UnityEngine;

public class CheckCollectibles : MonoBehaviour
{
    [SerializeField] private CollectibleManager collectibleManager;

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<ICollectible>() != null)
        {
            other.GetComponent<ICollectible>().Collect(collectibleManager);
            other.gameObject.SetActive(false);
        }
    }
}
