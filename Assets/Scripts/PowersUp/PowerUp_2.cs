using System.Collections;
using UnityEngine;

public class PowerUp_2 : PowerUp
{
    public float speedMultiplier = 2.5f;
    public float powerUpDuration;

    private void Awake()
    {
        powerUpType = PowerUpType.SpeedUp;
    }

    public override void Activate()
    {
        if (!isCooldown)
        {
            player.ActivatePowerUp(powerUpType);
            StartCoroutine(SpeedBoost());
            StartCoroutine(CooldownRoutine());
        }
    }

    private IEnumerator SpeedBoost()
    {
        float originalSpeed = player.speed;
        player.speed *= speedMultiplier;

        yield return new WaitForSeconds(powerUpDuration);

        player.speed = originalSpeed;
    }
}
