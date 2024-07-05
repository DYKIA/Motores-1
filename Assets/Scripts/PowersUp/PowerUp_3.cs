using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_3 : PowerUp
{
    //TP2 - Giuliano Acosta
    public GameObject bulletPrefab; // Prefab de la bala
    public Transform firePoint; // Punto desde donde se dispara la bala
    public float bulletSpeed; // Velocidad de la bala
    public float bulletLifeTime = 2.0f; // Tiempo de vida de la bala en segundos
    public override void Activate()
     {
         if (!isCooldown)
        {
            Debug.Log("Shoot Activated");
            Shoot();
            StartCoroutine(CooldownRoutine());
         }
     }
    private void Shoot()
    {
        // Instancia la bala en la posición y rotación del punto de disparo
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Obtiene el componente Rigidbody de la bala y aplica la fuerza
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;
        }
        // Destruir la bala después de un tiempo
        Destroy(bullet, bulletLifeTime);
    }

    private IEnumerator CooldownRoutine()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldownDuration);
        isCooldown = false;
    }


}
