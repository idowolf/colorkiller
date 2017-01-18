using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BGMusicScript : MonoBehaviour {
    public static bool AudioBegin = false;
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
        //if (isPlaying)
        //{
        //    GetComponent<AudioSource>().Stop();
        //    AudioBegin = false;
        //}
    }

}
