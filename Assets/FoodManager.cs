using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    [SerializeField] private PowerUp[] powerUps = new PowerUp[1000];
    [SerializeField] private BoxCollider gridArea;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPowerUps();
    }

    public void SpawnPowerUps()
    {
        for (int i = 0; i<powerUps.Length;i++)
        {
            powerUps[i].Initialize(gridArea);        
        }
    }
}
