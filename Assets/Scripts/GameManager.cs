using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameSettings gameSettings;
    [SerializeField] private PlayerMovement playerMovement;
    public void Start()
    {
        Time.fixedDeltaTime = gameSettings.GameSpeed;
    }
    
}
