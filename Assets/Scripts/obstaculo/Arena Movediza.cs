using UnityEngine;

public class ArenaMovediza : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Jugador player = collision.gameObject.GetComponent<Jugador>();
            if (player != null)
            {
                player.speed -= 2;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Jugador player = collision.gameObject.GetComponent<Jugador>();
            if (player != null)
            {
                player.speed += 2;
            }
        }
    }
}
