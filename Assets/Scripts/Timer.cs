using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    [SerializeField] GameOverManager gameOverManager;
    private bool isGameOverTriggered = false; // Prevent multiple calls

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;

            // Change color if time is less than 5 seconds
            if (remainingTime < 5)
            {
                timerText.color = Color.red;
            }
        }
        else if (!isGameOverTriggered) // Ensure the Game Over logic is called once
        {
            remainingTime = 0;
            Debug.Log("Player ran out of time!");
            TriggerGameOver(false);
        }

        // Update timer text display
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void TriggerGameOver(bool won)
    {
        // Set player win/loss state and load GameOver scene
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("PlayerWon", won ? 1 : 0);
        SceneManager.LoadScene("GameOverScene");
    }
}
