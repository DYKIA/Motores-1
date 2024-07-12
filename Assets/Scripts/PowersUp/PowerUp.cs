using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    //TP2 - Giuliano Acosta
    protected Jugador player; // Referencia al jugador
    public float cooldownDuration;
    protected bool isCooldown;
    public PowerUpType powerUpType; // Tipo de PowerUp

    // Método para inicializar el PowerUp con una referencia al jugador
    public void Initialize(Jugador player)
    {
        this.player = player;
    }
    // Método abstracto para activar el PowerUp
    public abstract void Activate();

    // Rutina de cooldown
    protected IEnumerator CooldownRoutine()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldownDuration);
        isCooldown = false;
    }
}
