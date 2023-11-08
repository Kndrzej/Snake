using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SlowerPlayerPowerUp : MonoBehaviour, IPowerUp
{
    [SerializeField] private float boostStrength = 0.015f;// refresh rate
    [SerializeField] private int boostTime = 2000;//in ms
    private float currentSpeed;

    public void Initialize(float x, float y)
    {
        this.gameObject.SetActive(true);
        float randomX = Random.Range(-x, x);
        float randomY = Random.Range(-y, y);
        this.transform.position = new Vector3(Mathf.Round(randomX), Mathf.Round(randomY), 0);
    }
   public void OnHit()
    {
        base.OnHit();
        currentSpeed = Time.fixedDeltaTime;
        BoostPlayerSpeed();
    }

    private async void BoostPlayerSpeed()
    {
        Time.fixedDeltaTime += boostStrength;
        await Task.Delay(boostTime);
        Time.fixedDeltaTime = currentSpeed;
    }
}
