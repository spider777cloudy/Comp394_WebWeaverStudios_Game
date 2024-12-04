using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered with: " + other.gameObject.name + " | Is Trigger: " + other.isTrigger);

        if (other.CompareTag("Trap"))
        {
            Debug.Log("Player touched the spike!");
            TriggerGameOver(false);
        }
        else if (other.CompareTag("End"))
        {
            Debug.Log("Player reached the finish line!");
            TriggerGameOver(true);
        }
        else
        {
            Debug.Log("Player triggered an untagged object: " + other.gameObject.name);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        CapsuleCollider2D collider = GetComponent<CapsuleCollider2D>();
        if (collider != null)
        {
            Gizmos.DrawWireSphere(transform.position, collider.size.x / 2); // This represents the player collider
        }
    }



    private void TriggerGameOver(bool won)
    {
        // Set player win/loss state and load GameOver scene

        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("PlayerWon", won ? 1 : 0);
        SceneManager.LoadScene("GameOverScene");
    }
}
