using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    [SerializeField] GameOverManager gameOverManager;

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
        else
        {
            // Ensure timer does not go below 0
            remainingTime = 0;

            // Trigger game over
            if (gameOverManager != null)
            {
                gameOverManager.ShowGameOverScreen(false); // Assuming 'false' means player lost
            }
        }

        // Update timer text display
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
