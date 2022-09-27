using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score = 0;
    [SerializeField] private int pointsForFood = 1;
    private TextMeshProUGUI text;
    private void OnEnable()
    {
        PlayerBody.OnPlayerCollision += UpdateScore;
        PlayerBody.OnGameReset += ResetScore;
    }
    private void OnDisable()
    {
        PlayerBody.OnPlayerCollision -= UpdateScore;
        PlayerBody.OnGameReset -= ResetScore;
    }
    private void Start()
    {
        text = this.GetComponent<TextMeshProUGUI>();
        UpdateScore();
    }
    void UpdateScore()
    {
        score += pointsForFood;
        text.text = "Food collected: " + score;
    }
    void ResetScore()
    {
        score = 0;
        text.text = "Food collected: " + score;
    }
}
