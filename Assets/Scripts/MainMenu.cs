﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string sceneName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // change scene when "new Game" is pressed
    static int points;

    public void StartGame()
    {
        Debug.Log("Hello");

        SceneManager.LoadScene(sceneName);
    }
}
