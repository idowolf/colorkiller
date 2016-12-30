using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {


    private float speed = 1000;
    public float rotSpeed = 2;
    private GameObject endRotation;

    // Use this for initialization
    void Start ()
    {
        endRotation = new GameObject();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            endRotation.transform.Rotate(Vector3.forward, rotSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.W))
        {
            endRotation.transform.Rotate(Vector3.forward, -rotSpeed, Space.World);
        }


        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, endRotation.transform.rotation, Time.deltaTime * speed);
    }



}
