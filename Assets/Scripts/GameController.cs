using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    [Header("UI Objects")]
    public TextMeshProUGUI scoreText;
    public GameObject gameOverTextObj;
    public GameObject restartTextObj;
    public TextMeshProUGUI timerText;

    private int score = 0;
    private bool gameover = false;
    private bool levelCompleted = false;
    private bool restart = false;
    public float timeLeft;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameover || levelCompleted)
        {
            // allow a way to quit the game
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        if (levelCompleted)
            return;

        // Check if we need to restart
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                // Restart our game.
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (!gameover)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft >= 0)
            {
                UpdateTimer(timeLeft);
            }
            else
            {
                GameOver();
            }
        }
    }

    void UpdateTimer(float currentTime)
    {
        timerText.text = string.Format($"{currentTime:00}");
    }

    public void AddToScore(int scoreValueToAdd)
    {
        score += scoreValueToAdd;
        // Debug.Log("Score: " + score);
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        // What happens whe my game is over?
        animator.SetBool("IsDead", true);
        
        gameover = true;
        restart = true;
        gameOverTextObj.SetActive(true);
        restartTextObj.SetActive(true);
    }

    public void SetLevelCompleted()
    {
        levelCompleted = true;
    }
}
