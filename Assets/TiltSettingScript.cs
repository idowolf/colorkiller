using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TiltSettingScript : MonoBehaviour {
    public static string callerScene = "level2";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //Rotate.androidTiltEnabled = true;
        if (TiltSettingScript.callerScene == "menu")
            SceneManager.LoadScene("menu");
        if (TiltSettingScript.callerScene == "level1")
            SceneManager.LoadScene("level2");
    }
}
