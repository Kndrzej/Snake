using UnityEngine;
public interface IPowerUp
{
    public void OnHit(IPowerUp powerUp);
    public delegate void PowerUpHit();
}
