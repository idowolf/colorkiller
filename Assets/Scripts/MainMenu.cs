using System.Collections;
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

    // change scene when "PLAY" is pressed
    void OnTriggerEnter2D(Collider2D other)
    {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            SceneManager.LoadScene(sceneName);
    }



}
