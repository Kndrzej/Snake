using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShorterPlayerPowerUp : PowerUp
{
    public override void OnHit()
    {
        base.OnHit();
        PlayerBody.Instance.Shrink();
    }
}
