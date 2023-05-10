using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeedUp : PowerUpBase
{
    [Header("PowerUp Speed Up")]
    public float newSpeed;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.PowerUpSpeedUp(newSpeed);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.ResetSpeed();
    }
}
