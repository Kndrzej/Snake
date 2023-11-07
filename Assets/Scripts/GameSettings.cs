using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "GameSettings")]
public class GameSettings : ScriptableObject
{
    public float gameSpeed;
    public int powerUpSpawnRate;
    //fppu faster player power up etc. lppu,sppu,rppu,shppu shorter player power up
    public int fppuNumber;
    public int lppuNumber;
    public int rppuNumber;
    public int shppuNumber;
    public int sppuNumber;
}
