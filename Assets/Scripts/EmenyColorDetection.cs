using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyColorDetection : MonoBehaviour {

    public string targetColor;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        string name = other.gameObject.name;
        if (name == targetColor)
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
