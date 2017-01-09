using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level1Logic : MonoBehaviour {

    public string sceneName;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (astroidFactory.score >= 20){
            SceneManager.LoadScene(sceneName);

        }

    }
}
