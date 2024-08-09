using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TP-Final Arraigada Gonzalo
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

        if (mainCamera != null)
        {
            move = mainCamera.transform.TransformDirection(move);
            move.y = 0;
        }

        if (move != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), 0.1f);
        }

        Move(move);
    }
}

