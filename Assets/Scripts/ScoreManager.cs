using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static long score;
    public int scoreToNext;               //score limit to finish level
    public string nextSceneName;          //next level  

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        changeLevel();
    }
    void changeLevel()
    {
        if (astroidFactory.score >= scoreToNext)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}

