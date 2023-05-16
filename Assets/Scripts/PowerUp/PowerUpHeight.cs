using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PowerUpHeight : PowerUpBase
{
    [Header("PowerUp Height")]
    public float newHeight = 2;
    public Ease ease = Ease.OutBack;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.SetHeight(newHeight, ease);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.SetHeight(-newHeight, ease);
    }
}
