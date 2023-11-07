using UnityEngine;
public abstract class PowerUp : MonoBehaviour
{
    public delegate void PowerUpPickUp();
    public PowerUpPickUp OnPowerUpPickUp;

    public void Initialize(float x, float y) 
    {
        this.gameObject.SetActive(true);
        float randomX = Random.Range(-x, x);
        float randomY = Random.Range(-y, y);
        this.transform.position = new Vector3(Mathf.Round(randomX), Mathf.Round(randomY), 0);
    }
    public virtual void OnHit()
    {
        this.gameObject.SetActive(false);
    }
}
