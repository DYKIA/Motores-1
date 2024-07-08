using UnityEngine;

public struct Collectible
{
    public string name;
    public Vector3 position;
    public int value;

    public Collectible(string name, Vector3 position, int value)
    {
        this.name = name;
        this.position = position;
        this.value = value;
    }
}
