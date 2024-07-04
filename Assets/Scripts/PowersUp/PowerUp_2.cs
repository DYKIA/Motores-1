using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_2 : PowerUp
{
    public float dashDistance;

    /*
    public override void Activate()
    {
        if (!isCooldown)
        {
            Debug.Log("Dash Activated");
            player.PerformDash(dashDistance);
            StartCoroutine(CooldownRoutine());
        }
    }



    private IEnumerator CooldownRoutine()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldownDuration);
        isCooldown = false;
    }

    */
}
