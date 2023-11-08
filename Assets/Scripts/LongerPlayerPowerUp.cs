using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongerPlayerPowerUp : PowerUp
{
   
    public override void OnHit()
    {
        base.OnHit();
        PlayerBody.Instance.Grow();
    }
}
