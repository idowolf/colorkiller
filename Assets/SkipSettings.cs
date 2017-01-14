using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SkipSettings : MonoBehaviour {
    // Use this for initialization
    public string sceneName;
	void Start () {
#if UNITY_EDITOR
        SceneManager.LoadScene(sceneName);
#endif
    }
    // Update is called once per frame
    void Update () {
		
	}
}
