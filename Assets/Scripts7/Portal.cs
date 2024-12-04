using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        Scene scene = SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Portal")
        {
            SceneManager.LoadSceneAsync(1);
        }



        if (collision.tag == "Portal1")
        {
            SceneManager.LoadSceneAsync(3);
        }


        if (collision.tag == "Portal2")
        {
            SceneManager.LoadSceneAsync(2);
        }

        if (collision.tag == "Portal3")
        {
            SceneManager.LoadSceneAsync(3);
        }

        if (collision.tag == "Portal4")
        {
            SceneManager.LoadSceneAsync(4);
        }

        if (collision.tag == "Portal5")
        {
            SceneManager.LoadSceneAsync(5);
        }

    }
}
