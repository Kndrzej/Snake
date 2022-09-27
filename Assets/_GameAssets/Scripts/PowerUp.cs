using UnityEngine;
public abstract class PowerUp : MonoBehaviour
{
    public abstract void Initialize(BoxCollider gridArea);
    public abstract void OnHit();
}
