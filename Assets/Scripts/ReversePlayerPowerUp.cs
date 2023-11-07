using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ReversePlayerPowerUp : MonoBehaviour, IPowerUp
{
    public delegate void ReversePlayerAction();
    public static event ReversePlayerAction OnPlayerReverse;

    public void Initialize(float x, float y)
    {
        this.gameObject.SetActive(true);
        float randomX = Random.Range(-x, x);
        float randomY = Random.Range(-y, y);
        this.transform.position = new Vector3(Mathf.Round(randomX), Mathf.Round(randomY), 0);
    }

    public void OnHit()
    {
        OnPlayerReverse();
        this.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        OnHit();
    }
    
}
