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

        bool flg1 = false;
        if (GetComponent<ColoredObject>() && other.GetComponent<ColoredObject>())

            flg1 = BulletCtrl.isDestroyable(gameObject) && gameObject.GetComponent<ColoredObject>().color == other.gameObject.GetComponent<ColoredObject>().color;
        bool flg2 = other.GetComponent<SpaceshipScript>();

        bool flg3 = GetComponent<SpaceshipScript>() && other.GetComponent<EnemyScript>();
        if (flg1 || flg2 || flg3)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            SceneManager.LoadScene(sceneName);
        }
    }



}
