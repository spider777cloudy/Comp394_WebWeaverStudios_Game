using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float defaultTime = 60f; // Default time set in Inspector
    private float remainingTime;
    [SerializeField] GameOverManager gameOverManager;
    private bool isGameOverTriggered = false; // Prevent multiple calls

    void Start()
    {
        // Reset timer to default value at the start of the scene
        ResetTimer();
        UpdateTimerText();
    }

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
        UpdateTimerText();
    }

    private void TriggerGameOver(bool won)
    {
        if (!isGameOverTriggered)
        {
            isGameOverTriggered = true; // Prevent multiple calls
            PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);
            PlayerPrefs.SetInt("PlayerWon", won ? 1 : 0);
            SceneManager.LoadScene("GameOverScene");
        }
    }

    private void ResetTimer()
    {
        remainingTime = defaultTime;
        timerText.color = Color.white; // Reset color to default
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Ensure the timer resets when the scene reloads
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //GameObject canvas = GameObject.Find("Canvas");
        //if (canvas != null)
        //{
        //    canvas.SetActive(true);
        //}
        ResetTimer();
    }
}
