using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SlowerPlayerPowerUp : PowerUp
{
    [SerializeField] private float boostStrength = 0.015f;// refresh rate
    [SerializeField] private int boostTime = 2000;//in ms
    float currentSpeed;

    public override void OnHit()
    {
        currentSpeed = Time.fixedDeltaTime;
        BoostPlayerSpeed();
        this.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        OnHit();
    }
    private async void BoostPlayerSpeed()
    {
        Time.fixedDeltaTime += boostStrength;
        await Task.Delay(boostTime);
        Time.fixedDeltaTime = currentSpeed;
    }
}
