using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject playAgainButton;
    [SerializeField] float startTime = 30f;

    float timeLeft;
    bool gameOver = false;

    public bool GameOver => gameOver;

    void Start()
    {
        timeLeft = startTime;
        Time.timeScale = 1f;
    }

    void Update()
    {
        DecreaseTime();
    }

    public bool ReturnGameOver()
    {
        return gameOver;
    }

    void DecreaseTime()
    {
        if (gameOver) return;

        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F1");

        if (timeLeft <= 0f)
        {
            PlayerGameOver();
        }
    }

    public void IncreaseTime(float amount)
    {
        if (gameOver) return;
        timeLeft += amount;
    }

    void PlayerGameOver()
    {
        gameOver = true;
        playerController.enabled = false;
        gameOverText.SetActive(true);
        playAgainButton.SetActive(true);
        timeLeft = 0;
        Time.timeScale = 0.1f;
    }

    public void RestartGame()
    {
        gameOverText.SetActive(false);
        playAgainButton.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
