using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Movement;

//TP2 - Joel Isaac Jim�nez
public class Controller : MonoBehaviour
{
    public void InputController()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
    }
}
