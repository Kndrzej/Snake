using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongerPlayerPowerUp : MonoBehaviour, IPowerUp
{
    public void Initialize(float x, float y)
    {
        this.gameObject.SetActive(true);
        float randomX = Random.Range(-x, x);
        float randomY = Random.Range(-y, y);
        this.transform.position = new Vector3(Mathf.Round(randomX), Mathf.Round(randomY), 0);
    }
    public void OnHit()
    {
        this.gameObject.SetActive(false);
        PlayerBody.Instance.Grow();
    }
    private void OnTriggerEnter(Collider other)
    {
        OnHit();
    }
}
