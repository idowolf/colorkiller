using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BGMusicScript : MonoBehaviour {
    static bool AudioBegin = false;
    public List<string> forbiddenNames = new List<string>{
        "GameOver",
        "credits",
        "menu"};
    void Awake()
    {
        if (!AudioBegin)
        {
            GetComponent<AudioSource>().Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
    }
    void Update()
    {
        if (forbiddenNames.IndexOf(SceneManager.GetActiveScene().name) != -1)
        {
            GetComponent<AudioSource>().Stop();
            AudioBegin = false;
        }
    }

}
