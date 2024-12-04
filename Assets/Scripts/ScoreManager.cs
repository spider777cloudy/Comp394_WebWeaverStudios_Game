//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class ScoreManager : MonoBehaviour
//{
//    public Text scoreText;
//    public Text hiScoreText;
//    public static int scoreCount;
//    public static int hiScoreCount;


//    // Start is called before the first frame update
//    void Start()
//    {
//        if (PlayerPrefs.HasKey("HighScore"))
//        {
//            hiScoreCount = PlayerPrefs.GetInt("HiScore");
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if(scoreCount>hiScoreCount)
//        {
//            hiScoreCount = scoreCount;
//            PlayerPrefs.SetInt("HighScore", hiScoreCount);
//        }
//        scoreText.text = "SCORE: " + scoreCount;
//        hiScoreText.text = "HI-SCORE: " + hiScoreCount;
//    }
//}


using UnityEngine;
using UnityEngine.UI; // Include this for Text component

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Singleton instance
    private int score;

    [SerializeField] private Text scoreText; // Reference to the UI Text element

    void Awake()
    {
        // Ensure there is only one instance of ScoreManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log($"Score: {score}");

        // Update the UI text with the new score
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public int GetScore()
    {
        return score;
    }
}
