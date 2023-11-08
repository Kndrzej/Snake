using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "GameSettings")]
public class GameSettings : ScriptableObject
{
    public float GameSpeed;
    public int PowerUpSpawnRate;
    public int FasterPlayerPowerUpNumber;
    public int LongerPlayerPowerUpNumber;
    public int ReversePlayerPowerUpNumber;
    public int ShorterPlayerPowerUpNumber;
    public int SlowerPlayerPowerUpNumber;
}
