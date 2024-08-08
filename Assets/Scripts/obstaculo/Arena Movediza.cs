
using UnityEngine;
using Movement;
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
