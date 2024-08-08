using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Movement;

//TP2 - Joel Isaac Jiménez
public abstract class Controller : MonoBehaviour
{
    public float speed;
    public float gravity = 10f;

    public void InputController()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(moveHorizontal, 0, moveVertical);

        transform.position = transform.position + move * speed * Time.deltaTime;
    }
}
