using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCoins : PowerUpBase
{
    [Header("PowerUp Coins")]
    public float newSize;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.ChangeCoinCollectorSize(newSize);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.ChangeCoinCollectorSize();
    }
}
