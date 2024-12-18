using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void LoadLevel01()
    {
        SceneManager.LoadScene("Main"); 
    }

    public void LoadLevel02()
    {
        SceneManager.LoadScene("New Scene");
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadL2()
    {
        SceneManager.LoadScene(" [2] SCENE_VM");
    }


    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting"); 
    }
   


}
