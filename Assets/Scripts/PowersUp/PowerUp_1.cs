using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_1 : PowerUp
{
    
    public float shieldDuration; // Duración del escudo en segundos
    private bool isShieldActive = false; // Estado del escudo activo
    public float shieldStrength; // Fuerza del escudo (cantidad de daño absorbido)

    private void Awake()
    {
        powerUpType = PowerUpType.Shield;
    }
    public override void Activate()
    {
        if (!isCooldown)
        {
            player.ActivatePowerUp(powerUpType);
            StartCoroutine(ActivateShield());
            StartCoroutine(CooldownRoutine());
        }
    }

    IEnumerator ActivateShield()
    {
        isCooldown = true; // Inicia el cooldown
        isShieldActive = true;

        Debug.Log("Shield Activated");

        // Proteger al jugador mientras el escudo esté activo
       // player.isShielded = true;

        yield return new WaitForSeconds(shieldDuration); // Espera la duración del escudo

        Debug.Log("Shield Desactivated");

        // Desproteger al jugador
        //player.isShielded = false;
        isShieldActive = false;
        isCooldown = false; // Finaliza el cooldown
    }

}
