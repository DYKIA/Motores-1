using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Movement;

//TP2 - Joel Isaac Jiménez
public abstract class Jugador : Controller, IMovement
{
    public float speed;
    public float life;

    private Transform target;

    public float jumpForce { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public Rigidbody rb { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float move { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    private void Update()
    {
        InputController();
    }

}


