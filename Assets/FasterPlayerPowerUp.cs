using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FasterPlayerPowerUp : PowerUp
{
    [SerializeField] private float boostStrength = 0.015f;// refresh rate
    [SerializeField] private int boostTime = 2000;//in ms
    float currentSpeed;

    public override void Initialize(BoxCollider gridArea)
    {
        this.gameObject.SetActive(true);

        Bounds bounds = gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0);
    }

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
        Time.fixedDeltaTime -= boostStrength;
        await Task.Delay(boostTime);
        Time.fixedDeltaTime = currentSpeed;
    }
}
