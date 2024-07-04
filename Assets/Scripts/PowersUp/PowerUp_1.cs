using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_1 : PowerUp
{
    public float shieldDuration;


    /*  public override void Activate()
    {
        if (!isCooldown)
        {
            Debug.Log("Shield Activated");
            player.ActivateShield(shieldDuration);
            StartCoroutine(CooldownRoutine());
        }
    }

   
    public override void Deactivate()
    {
        Debug.Log("Shield Deactivated");
        player.DeactivateShield();
    }

   
    
    private IEnumerator CooldownRoutine()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldownDuration);
        isCooldown = false;
    }

    */

}
