using UnityEngine;
using System.Collections.Generic;
//TP-Final Arraigada Gonzalo
public class CollectibleSystem : MonoBehaviour
{
    private List<Collectible> collectibles;

    public int playerPoints;

    void Start()
    {

        collectibles = new List<Collectible> //seteo posicion y valor de los 3 items :p
        {
            new Collectible("Coin", new Vector3(-15, 6, 55), 10),
            new Collectible("Gem", new Vector3(-30, 8, -21), 50),
            new Collectible("Star", new Vector3(17, 11, -26), 100)
        };


        foreach (var collectible in collectibles)
        {
            CreateCollectible(collectible); // creo los coleccionables 
        }

        playerPoints = 0;
    }

    void CreateCollectible(Collectible collectible) // metodo q crea los coleccionables
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