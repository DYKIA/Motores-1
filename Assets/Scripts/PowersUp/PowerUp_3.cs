using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_3 : PowerUp
{
    public float newSpeed;

   /* public override void Activate()
    {
        if (!isCooldown)
        {
            Debug.Log("Speed Boost Activated");
            player.SetSpeed(newSpeed);
            StartCoroutine(CooldownRoutine());
        }
    }

    public override void Deactivate()
    {
        Debug.Log("Speed Boost Deactivated");
        player.ResetSpeed();
    }

    private IEnumerator CooldownRoutine()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldownDuration);
        isCooldown = false;
        Deactivate();
    }
    */
}
