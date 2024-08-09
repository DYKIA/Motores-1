using UnityEngine;
//TP-Final Arraigada Gonzalo
public class CollectibleItem : MonoBehaviour  //codigo q tendran los items dentro
{    
    private Collectible collectible;

    public void Setup(Collectible collectible)
    {
        this.collectible = collectible;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Jugador>())
        {
            //Debug.Log("Collected: " + collectible.name);
            FindObjectOfType<CollectibleSystem>().CollectItem(collectible);
            Destroy(gameObject);
        }
    }
}