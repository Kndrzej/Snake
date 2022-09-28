using UnityEngine;
public abstract class PowerUp : MonoBehaviour
{
    public abstract void Initialize(float x, float y);
    public abstract void OnHit();
}
