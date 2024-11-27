using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText; // Reference to the TMP text component
    public string winMessage = "You Win!";
    public string loseMessage = "You Lose!";

    void Start()
    {
        if (gameOverText == null)
        {
            Debug.LogError("GameOverManager: gameOverText is not assigned!");
        }

        // Check if the player won or lost
        bool playerWon = PlayerPrefs.GetInt("PlayerWon") == 1;

        // Display the appropriate message
        ShowGameOverScreen(playerWon);
    }

    public void ShowGameOverScreen(bool won)
    {
        if (gameOverText != null)
        {
            gameOverText.text = won ? winMessage : loseMessage;
        }
        else
        {
            Debug.LogError("ShowGameOverScreen: gameOverText is not assigned!");
        }

        SceneManager.LoadScene("[2]SCENE_VM");
    }

    public void LoadLevel01()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
