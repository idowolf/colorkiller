using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {


    private float speed = 1000;
    public float rotSpeed = 2;
    public float androidRotSpeed = 5;
    private GameObject endRotation;
    // Use this for initialization
    void Start ()
    {
        endRotation = new GameObject();
#if UNITY_ANDROID
        Input.compensateSensors = true;
        Input.gyro.enabled = true;
#endif
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
#if UNITY_ANDROID
        this.transform.Rotate(0, 0, -Input.gyro.rotationRateUnbiased.z * androidRotSpeed);
#endif
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            endRotation.transform.Rotate(Vector3.forward, rotSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            endRotation.transform.Rotate(Vector3.forward, -rotSpeed, Space.World);
        }
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, endRotation.transform.rotation, Time.deltaTime * speed);
#endif
    }
}
