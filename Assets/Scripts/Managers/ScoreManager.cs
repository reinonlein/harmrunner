using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameManager gameManager;

    int score = 0;

    void Start()
    {
        scoreText.text = score.ToString();
    }

    public void IncreaseScore(int amount)
    {
        if (gameManager.GameOver) return;

        score += amount;
        scoreText.text = score.ToString();
    }
}
