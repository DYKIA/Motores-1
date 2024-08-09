using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_3 : PowerUp
{
    
    public GameObject bulletPrefab; // Prefab de la bala
    public Transform firePoint; // Punto desde donde se dispara la bala
    public float bulletSpeed; // Velocidad de la bala
    public float bulletLifeTime = 2.0f; // Tiempo de vida de la bala en segundos

    private void Awake()
    {
        powerUpType = PowerUpType.Shoot;
    }
    public override void Activate()
     {
         if (!isCooldown)
        {
            player.ActivatePowerUp(powerUpType);
            Debug.Log("Shoot Activated");
            Shoot();
            StartCoroutine(CooldownRoutine());
         }
     }
    private void Shoot()
    {     
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }





}
