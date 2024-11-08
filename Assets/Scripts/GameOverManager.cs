using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;  // Reference to the TMP text component
    public string winMessage = "You Win!";
    public string loseMessage = "You Lose!";

    void Start()
    {
        // Check if the player won or lost
        bool playerWon = PlayerPrefs.GetInt("PlayerWon") == 1;

        // Display the appropriate message
        ShowGameOverScreen(playerWon);
    }

    // Function to show the correct game over message
    public void ShowGameOverScreen(bool won)
    {
        gameOverText.text = won ? winMessage : loseMessage;
    }

    // Function for the Play Again button
    public void PlayAgain()
    {
        // Reload the last played level
        SceneManager.LoadScene(PlayerPrefs.GetString("CurrentLevel"));
    }

    // Function for the Main Menu button
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");  // Make sure you have a MainMenu scene created
    }
}
