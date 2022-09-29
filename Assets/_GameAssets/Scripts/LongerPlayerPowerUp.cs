using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongerPlayerPowerUp : PowerUp
{
    public override void OnHit()
    {
        this.gameObject.SetActive(false);
        PlayerBody.Instance.Grow();
    }
    private void OnTriggerEnter(Collider other)
    {
        OnHit();
    }
}
