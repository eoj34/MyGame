using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int player1Score = 0;
    public int player2Score = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    public GameObject puck;

    private float elapsedTime = 0f;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateTimerText();
    }

    public void AddScore(bool isPlayer1)
    {
        if (isPlayer1)
            player1Score++;
        else
            player2Score++;

        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = player1Score + " : " + player2Score;
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60F);
        int seconds = Mathf.FloorToInt(elapsedTime % 60F);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

