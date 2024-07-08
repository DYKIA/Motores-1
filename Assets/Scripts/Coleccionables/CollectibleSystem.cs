using UnityEngine;
using System.Collections.Generic;

public class CollectibleSystem : MonoBehaviour
{
    private List<Collectible> collectibles;

    private int playerPoints;

    void Start()
    {

        collectibles = new List<Collectible> //seteo posicion y valor de los 3 items :p
        {
            new Collectible("Coin", new Vector3(1, 0, 1), 10),
            new Collectible("Gem", new Vector3(2, 0, 2), 50),
            new Collectible("Star", new Vector3(3, 0, 3), 100)
        };


        foreach (var collectible in collectibles)
        {
            CreateCollectible(collectible);
        }

        playerPoints = 0;
    }

    void CreateCollectible(Collectible collectible)
    {

        GameObject collectibleObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        collectibleObject.transform.position = collectible.position;
        collectibleObject.name = collectible.name;

        collectibleObject.GetComponent<Collider>().isTrigger = true;

        collectibleObject.AddComponent<CollectibleItem>().Setup(collectible);
    }


    public void CollectItem(Collectible collectible) // sumo los puntos al recojer el item
    {
        playerPoints += collectible.value;
        Debug.Log("Collected: " + collectible.name + ". Total Points: " + playerPoints);
    }
}