using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    private Collectible collectible;

    public void Setup(Collectible collectible)
    {
        this.collectible = collectible;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Debug.Log("Collected: " + collectible.name);
            Destroy(gameObject);


            FindObjectOfType<CollectibleSystem>().CollectItem(collectible);
        }
    }
}