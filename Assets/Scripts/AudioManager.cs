using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private void OnEnable()
    {
       PowerUp.OnPowerUpPickUp += PlayPickUpSound;
       //SlowerPlayerPowerUp.OnPowerUpPickUp += PlayPickUpSound;
       //ShorterPlayerPowerUp.Instance.OnPowerUpPickUp += PlayPickUpSound;
       //ReversePlayerPowerUp.Instance.OnPowerUpPickUp += PlayPickUpSound;
      // LongerPlayerPowerUp.Instance.OnPowerUpPickUp += PlayPickUpSound;
      // FasterPlayerPowerUp.Instance.OnPowerUpPickUp += PlayPickUpSound;
    }
    void PlayPickUpSound()
    {
        Debug.Log("play sound");
    }
}
