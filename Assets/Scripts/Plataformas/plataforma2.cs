using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TP-Final Fernando Nogueira
public class Plataforma2 : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Velocidad de movimiento de la plataforma
    public float moveDistance = 5.0f; // Distancia total que recorre la plataforma

    private Vector3 initialPosition;
    private bool movingRight = true;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        // Calcula el desplazamiento basado en el tiempo
        float movement = moveSpeed * Time.deltaTime;

        // Determina la dirección del movimiento
        if (movingRight)
        {
            transform.Translate(Vector3.right * movement);
        }
        else
        {
            transform.Translate(Vector3.left * movement);
        }

        // Revisa si la plataforma ha alcanzado su límite de movimiento
        if (Mathf.Abs(transform.position.z - initialPosition.z) >= moveDistance)
        {
            // Cambia la dirección
            movingRight = !movingRight;
        }
    }
}

