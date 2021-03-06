﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsOnClick : MonoBehaviour
{

    public string sceneName;          //next level  
    public string overrideSettingsScene;
    private bool amIOnPC;
    private bool changing;
    // Use this for initialization
    void Start()
    {
#if UNITY_EDITOR
        amIOnPC = true;
#endif
    }

    public void OnClick()
    {
        if (!changing)
        {
            if (overrideSettingsScene != "" && amIOnPC)
                PassageMovement.passedArgument = overrideSettingsScene;
            else
                PassageMovement.passedArgument = sceneName;
            StartCoroutine(changeScene());
        }
    }

    IEnumerator changeScene()
    {
        if (!changing)
        {
            if (GetComponent<AudioSource>())
                GetComponent<AudioSource>().Play();
            changing = true;
            float ElapsedTime = 0.0f;
            float TotalTime = 0.5f;
            while (ElapsedTime < TotalTime)
            {
                ElapsedTime += Time.deltaTime;
                (Instantiate(Resources.Load("Blackscreen") as GameObject)).gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(new Color(1, 1, 1, 0), Color.black, (ElapsedTime / TotalTime));
                yield return null;
            }
            Debug.Log("Lookie here");
            ScoreManager.score = 0;
            if (sceneName == "credits" || sceneName == "menu")
                SceneManager.LoadScene(PassageMovement.passedArgument);
            else
                SceneManager.LoadScene("passage");
        }
    }

    //IEnumerator WaitForIt(float waitTime)
    //{
    //    yield return new WaitForSeconds(waitTime);
    //    SceneManager.LoadScene(sceneName);
    //}
}