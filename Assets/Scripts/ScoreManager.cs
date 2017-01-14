using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public int scoreToNext;               //score limit to finish level
    public string nextSceneName;          //next level  
    public Text scoreText;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        changeLevel();
        setScoreText();

    }
    void changeLevel()
    {
        if (ScoreManager.score >= scoreToNext)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    void setScoreText()
    {
        scoreText.text = "SCORE : " + (ScoreManager.score*(10)).ToString();
    }
    
}

