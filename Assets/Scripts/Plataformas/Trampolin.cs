using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : Jugador
{
    public float bounceForce;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BouncePlayer();
        }
    }

    void BouncePlayer()
    {
        // Aplica una fuerza de impulso al jugador cuando colisiona con el trampolín
        rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
    }
}