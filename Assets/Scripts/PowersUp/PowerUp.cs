using System.Collections;
using UnityEngine;
//TP-Final Santiago Da Valinha
public abstract class PowerUp : MonoBehaviour
{
    protected Jugador player; // Referencia al jugador
    public float cooldownDuration;
    protected bool isCooldown;
    public PowerUpType powerUpType; // Tipo de PowerUp

    // M�todo para inicializar el PowerUp con una referencia al jugador
    public void Initialize(Jugador player)
    {
        this.player = player;
    }
    // M�todo abstracto para activar el PowerUp
    public abstract void Activate();

    // Rutina de cooldown
    protected IEnumerator CooldownRoutine()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldownDuration);
        isCooldown = false;
    }
}
