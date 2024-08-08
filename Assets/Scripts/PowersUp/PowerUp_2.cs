using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_2 : PowerUp
{
   
    public float dashDistance;
    public float dashDuration;


    private void Awake()
    {
        powerUpType = PowerUpType.Dash;
    }

    public override void Activate()
    {
        if (!isCooldown)
        {
            player.ActivatePowerUp(powerUpType);
            Debug.Log("Dash Activated");
            StartCoroutine(Dash());
            StartCoroutine(CooldownRoutine());
        }
    }

    private IEnumerator Dash()
    {
        Vector3 initialPosition = player.transform.position;
        Vector3 dashDirection = player.transform.forward;
        float elapsedTime = 0;

        while (elapsedTime < dashDuration)
        {
            player.rb.MovePosition(initialPosition + dashDirection * (dashDistance * (elapsedTime / dashDuration)));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        player.rb.MovePosition(initialPosition + dashDirection * dashDistance);
    }


}
