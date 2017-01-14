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

        bool flg1 = false;
        if (GetComponent<ColoredObject>() && other.GetComponent<ColoredObject>())

            flg1 = BulletCtrl.isDestroyable(gameObject) && gameObject.GetComponent<ColoredObject>().color == other.gameObject.GetComponent<ColoredObject>().color;
        bool flg2 = other.GetComponent<SpaceshipScript>();

        bool flg3 = GetComponent<SpaceshipScript>() && other.GetComponent<EnemyScript>();
        if (flg1 || flg2 || flg3)
        {
            StartCoroutine(WaitForIt(0.99F));
            Debug.Log("TEST");
            //SceneManager.LoadScene(sceneName);
        }
    }

    IEnumerator WaitForIt(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneName);
    }
}

