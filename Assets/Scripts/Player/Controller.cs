using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    public float speed;
    public float gravity = 10f;
  
    public Camera mainCamera;

    protected abstract void Move(Vector3 direction);

    public void InputController()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 move = new Vector3(moveHorizontal, 0, moveVertical);

        // Usa la cámara para ajustar la dirección del movimiento
        if (mainCamera != null)
        {
            move = mainCamera.transform.TransformDirection(move);
            move.y = 0; // Opcional, dependiendo si deseas mover en el eje Y
        }

        Move(move);
    }
}
