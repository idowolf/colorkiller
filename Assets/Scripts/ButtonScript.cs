using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

    public string sceneName;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
            StartCoroutine(WaitForIt(0.99F));
            Debug.Log("TEST");
            SceneManager.LoadScene(sceneName);
    }

    IEnumerator WaitForIt(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneName);
    }
}

