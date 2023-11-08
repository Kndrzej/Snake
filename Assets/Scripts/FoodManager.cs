using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    [SerializeField] private GameObject[] powerUpsPrefab = new GameObject[10];
    [SerializeField] private List<GameObject> powerUps = new List<GameObject>();
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
        powerUpSpawnRate = gameSettings.PowerUpSpawnRate;
        //if you create new powerup you must add it here to total value
        var powerUpsAmount = gameSettings.FasterPlayerPowerUpNumber + gameSettings.SlowerPlayerPowerUpNumber + gameSettings.ShorterPlayerPowerUpNumber + gameSettings.ReversePlayerPowerUpNumber + gameSettings.LongerPlayerPowerUpNumber;
        SpawnPowerUpsFromGameSettings();
        //turn them off on start, we will turn them on later
        foreach (GameObject powerUp in powerUps)
        {
            powerUp.gameObject.SetActive(false);
        }
    }

    private void SpawnPowerUpsFromGameSettings()
    {
        //spawn faster 
        for (int i = 0; i < gameSettings.FasterPlayerPowerUpNumber; i++)
        {
            powerUps.Add(Instantiate(powerUpsPrefab[0]));
        }
        //spawn slower
        for (int i = 0; i < gameSettings.SlowerPlayerPowerUpNumber; i++)
        {
            powerUps.Add(Instantiate(powerUpsPrefab[1]));
        }
        //spawn reverse
        for (int i = 0; i < gameSettings.ReversePlayerPowerUpNumber; i++)
        {
            powerUps.Add(Instantiate(powerUpsPrefab[2]));
        }
        //spawn longer
        for (int i = 0; i < gameSettings.LongerPlayerPowerUpNumber; i++)
        {
            powerUps.Add(Instantiate(powerUpsPrefab[3]));
        }
        //spawn shorter
        for (int i = 0; i < gameSettings.ShorterPlayerPowerUpNumber; i++)
        {
            powerUps.Add(Instantiate(powerUpsPrefab[4]));
        }
    }

    public void SpawnPowerUp(float x, float y)
    {
        var powerUp = Random.Range(0,powerUps.Count);
        if (powerUps[powerUp].TryGetComponent<SlowerPlayerPowerUp>(out SlowerPlayerPowerUp slowerPlayerPowerUp))
        {
            slowerPlayerPowerUp.Initialize(x, y);
        }
        else if (powerUps[powerUp].TryGetComponent<ShorterPlayerPowerUp>(out ShorterPlayerPowerUp shorterPlayerPowerUp))
        {
            shorterPlayerPowerUp.Initialize(x, y);
        }
        else if (powerUps[powerUp].TryGetComponent<ReversePlayerPowerUp>(out ReversePlayerPowerUp reversePlayerPowerUp))
        {
            reversePlayerPowerUp.Initialize(x, y);
        }
        else if (powerUps[powerUp].TryGetComponent<FasterPlayerPowerUp>(out FasterPlayerPowerUp fasterPlayerPowerUp))
        {
            fasterPlayerPowerUp.Initialize(x, y);
        }
        else if (powerUps[powerUp].TryGetComponent<LongerPlayerPowerUp>(out LongerPlayerPowerUp longerPlayerPowerUp))
        {
            longerPlayerPowerUp.Initialize(x, y);
        }

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
