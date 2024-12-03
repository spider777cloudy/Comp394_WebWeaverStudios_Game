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

       // SceneManager.LoadScene("[2]SCENE_VM");
    }

    public void LoadLevel01()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadLevel02()
    {
        SceneManager.LoadScene("[2]SCENE_VM");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Collision detected with: {collision.gameObject.name} (Tag: {collision.gameObject.tag})");
        // Check if the colliding object has the tag "level2"
        if (collision.gameObject.CompareTag("levelp"))
        {
            Debug.Log("Collided with Level 2 trigger!");
            LoadLevel02();
        }
    }

    // Optional: Use OnTriggerEnter if the GameObject uses a trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Trigger detected with: {other.gameObject.name} (Tag: {other.gameObject.tag})");
        // Check if the triggering object has the tag "level2"
        if (other.gameObject.CompareTag("levelp"))
        {
            Debug.Log("Entered Level 2 trigger!");
            LoadLevel02();
        }
        if (other.gameObject.CompareTag("level1"))
        {
            Debug.Log("Entered Level 2 trigger!");
            LoadLevel01();
        }
    }

}
