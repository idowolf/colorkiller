using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public int scoreToNext;               //score limit to finish level
    public string sceneName;          //next level  
    public string overrideSettingsScene;
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
    }

    // Update is called once per frame
    void Update()
    {
        changeLevel();
        setScoreText();

    }
    void changeLevel()
    {
        if (ScoreManager.score >= scoreToNext )
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
        scoreText.text = "SCORE : " + (ScoreManager.score * (10)).ToString();
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
            if (sceneName == "settings")
                TiltSettingScript.callerScene = SceneManager.GetActiveScene().name;
            if (sceneName == "credits" || sceneName == "menu" || sceneName == "settings" || sceneName == "settingsPC")
                SceneManager.LoadScene(PassageMovement.passedArgument);
            else
                SceneManager.LoadScene("passage");
        }
    }


}