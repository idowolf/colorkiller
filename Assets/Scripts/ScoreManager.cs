using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public int levelScore;
    private int initScore;
    public int scoreToNext;               //score limit to finish level
    public static int prevScoresToNext = 0;
    public string sceneName;          //next level  
    public string overrideSettingsScene;
    public static string currentSceneName = "menu";
    public Text scoreText;
    Material mat;
    private bool amIOnPC;
    private bool changing;
    // Use this for initialization
    void Start()
    {
#if UNITY_EDITOR
        amIOnPC = true;
#endif
        initScore = score;
        currentSceneName = SceneManager.GetActiveScene().name;

    }

    // Update is called once per frame
    void Update()
    {
        levelScore = score - initScore;
        changeLevel();
        setScoreText();

    }
    void changeLevel()
    {
        if (levelScore >= scoreToNext )
        {
            if (!changing) {
                astroidFactory.score = 0;
                if (overrideSettingsScene != "" && amIOnPC)
                { 
                    PassageMovement.passedArgument = overrideSettingsScene;
                }
                else
                { 
                    PassageMovement.passedArgument = sceneName;
                }
                StartCoroutine(changeScene());
            }
        }
    }

    void setScoreText()
    {
        if(scoreText)
            scoreText.text = "SCORE : " + (ScoreManager.score * (10)).ToString() + " / " + ((scoreToNext + prevScoresToNext)*10).ToString();
    }

    IEnumerator changeScene()
    {
        if(!changing)
        {
            changing = true;
        float ElapsedTime = 0.0f;
        float TotalTime = 0.5f;
        while (ElapsedTime < TotalTime)
        {
            ElapsedTime += Time.deltaTime;
            (Instantiate (Resources.Load("Blackscreen") as GameObject)).gameObject.GetComponent<SpriteRenderer>().color= Color.Lerp(new Color(1, 1, 1, 0), Color.black, (ElapsedTime / TotalTime));
            yield return null;
        }
            prevScoresToNext += scoreToNext + (levelScore - scoreToNext);
            if (sceneName == "credits" || sceneName == "menu" || sceneName == "dialtutorial")
                SceneManager.LoadScene(PassageMovement.passedArgument);
            else
                SceneManager.LoadScene("passage");
        }
    }


}