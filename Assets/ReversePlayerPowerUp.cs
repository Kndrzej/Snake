using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ReversePlayerPowerUp : PowerUp
{
    public delegate void ReversePlayerAction();
    public static event ReversePlayerAction OnPlayerReverse;
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
        OnPlayerReverse();
        this.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        OnHit();
    }
    
}
