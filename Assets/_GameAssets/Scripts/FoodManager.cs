using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    [SerializeField] private GameObject[] powerUpsPrefab = new GameObject[10];
    [SerializeField] private List<PowerUp> powerUps = new List<PowerUp>();
    [SerializeField] private BoxCollider gridArea;
    [SerializeField] private GameSettings gameSettings;
    private int powerUpSpawnRate;
    private float timer = 0;
    private float gridAreaX;
    private float gridAreaY;
    void Start()
    {
        gridAreaX = gridArea.bounds.extents.x;
        gridAreaY = gridArea.bounds.extents.y;
        gridArea.enabled = false;
        powerUpSpawnRate = gameSettings.powerUpSpawnRate;
        //if you create new powerup you must add it here to total value
        var powerUpsAmount = gameSettings.fppuNumber + gameSettings.shppuNumber + gameSettings.sppuNumber + gameSettings.rppuNumber + gameSettings.lppuNumber;
        SpawnPowerUpsFromGameSettings();
        //turn them off on start, we will turn them on later
        foreach (PowerUp powerUp in powerUps)
        {
            powerUp.gameObject.SetActive(false);
        }
    }

    private void SpawnPowerUpsFromGameSettings()
    {
        //spawn faster 
        for (int i = 0; i < gameSettings.fppuNumber; i++)
        {
            powerUps.Add(Instantiate(powerUpsPrefab[0]).GetComponent<PowerUp>());
        }
        //spawn slower
        for (int i = 0; i < gameSettings.sppuNumber; i++)
        {
            powerUps.Add(Instantiate(powerUpsPrefab[1]).GetComponent<PowerUp>());
        }
        //spawn reverse
        for (int i = 0; i < gameSettings.rppuNumber; i++)
        {
            powerUps.Add(Instantiate(powerUpsPrefab[2]).GetComponent<PowerUp>());
        }
        //spawn longer
        for (int i = 0; i < gameSettings.lppuNumber; i++)
        {
            powerUps.Add(Instantiate(powerUpsPrefab[3]).GetComponent<PowerUp>());
        }
        //spawn shorter
        for (int i = 0; i < gameSettings.shppuNumber; i++)
        {
            powerUps.Add(Instantiate(powerUpsPrefab[4]).GetComponent<PowerUp>());
        }
    }

    public void SpawnPowerUp(float x, float y)
    {
        var powerUp = Random.Range(0,powerUps.Count);
        powerUps[powerUp].Initialize(x,y);
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > powerUpSpawnRate)
        {
            timer = 0;
            SpawnPowerUp(gridAreaX, gridAreaY);
        }
    }
}
