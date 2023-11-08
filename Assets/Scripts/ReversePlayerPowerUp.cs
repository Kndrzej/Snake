using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ReversePlayerPowerUp : PowerUp
{
    public delegate void ReversePlayerAction();
    public static event ReversePlayerAction OnPlayerReverse;

    public override void OnHit()
    {
        base.OnHit();
        OnPlayerReverse();
    }
}
