using UnityEngine;

//TP-Final Arraigada Gonzalo
public class ArenaMovediza : MonoBehaviour
{
    public Jugador jugador;
    public float NewSpeed;
    public float NormalSpeed;
    public float Slow= 3f;
    private void Start()
    {
        NormalSpeed = jugador.speed;
        NewSpeed = NormalSpeed-Slow;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<Jugador>())
        {
            Jugador player = collision.gameObject.GetComponent<Jugador>();
            if (player != null)
            {
                player.speed = NewSpeed;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Jugador>())
        {
            Jugador player = collision.gameObject.GetComponent<Jugador>();
            if (player != null)
            {
                player.speed = NormalSpeed;
            }
        }
    }
}
