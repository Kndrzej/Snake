using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShorterPlayerPowerUp : PowerUp
{

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
        this.gameObject.SetActive(false);
        PlayerBody.Instance.Shrink();
    }
    private void OnTriggerEnter(Collider other)
    {
        OnHit();
    }
}
