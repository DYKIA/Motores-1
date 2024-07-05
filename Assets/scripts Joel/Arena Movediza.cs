using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Movement;

//TP2 - Joel Isaac Jiménez
public class ArenaMovediza : Jugador, IMovement
{
    private void OnCollisionStay(Collision collision)
    {
        speed -= 2;
    }
    private void OnCollisionExit(Collision collision)
    {
        speed += 2;
    }
}
