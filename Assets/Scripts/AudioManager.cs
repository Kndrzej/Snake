using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickUpSound;
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
        audioSource.PlayOneShot(pickUpSound);
    }
}
