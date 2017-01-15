using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerScript : MonoBehaviour {
    float time;
	// Use this for initialization
	void Start () {
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time < 5.0f)
            GetComponent<Text>().text = "TIME LEFT: " + string.Format("{0:0.##}",5.0f - time);
        else
            GameObject.Destroy(gameObject);
	}
}
