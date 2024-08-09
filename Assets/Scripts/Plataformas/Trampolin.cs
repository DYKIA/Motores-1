using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
    public float bounceForce;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Jugador>())
        {
            BouncePlayer(collision.gameObject.GetComponent<Rigidbody>());
        }
    }

    void BouncePlayer(Rigidbody playerRb)
    {
        // Aplica una fuerza de impulso al jugador cuando colisiona con el trampolín
        playerRb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
    }
}
