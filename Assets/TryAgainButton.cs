using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgainButton : MonoBehaviour
{
    private bool changing;
    // Use this for initialization
    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!changing)
        {
            StartCoroutine(changeScene());
        }
    }

    IEnumerator changeScene()
    {
        if (!changing)
        {
            changing = true;
            float ElapsedTime = 0.0f;
            float TotalTime = 0.5f;
            while (ElapsedTime < TotalTime)
            {
                ElapsedTime += Time.deltaTime;
                (Instantiate(Resources.Load("Blackscreen") as GameObject)).gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(new Color(1, 1, 1, 0), Color.black, (ElapsedTime / TotalTime));
                yield return null;
            }
            ScoreManager.score = 0;
            PassageMovement.passedArgument = ScoreManager.currentSceneName;
            Debug.Log(PassageMovement.passedArgument);
            SceneManager.LoadScene("passage");
        }
    }
}