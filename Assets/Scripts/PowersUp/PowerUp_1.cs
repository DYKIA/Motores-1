using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TP-Final Santiago Da Valinha
public class PowerUp_1 : PowerUp
{   
    public float shieldDuration; // Duración del escudo en segundos
    private void Awake()
    {
        powerUpType = PowerUpType.Shield;    
    }
    private void Start()
    {
        player.isShielded = false;
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
        Debug.Log("Shield Activated");

        // Proteger al jugador mientras el escudo esté activo
        player.isShielded = true;

        yield return new WaitForSeconds(shieldDuration); // Espera la duración del escudo

        Debug.Log("Shield Desactivated");

        // Desproteger al jugador
        player.isShielded = false;       
        isCooldown = false; // Finaliza el cooldown
    }

}
