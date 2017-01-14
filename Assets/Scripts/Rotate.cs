using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public enum InputCmd
{
    DoNone,
    RotateLeft,
    RotateRight
}
public class Rotate : MonoBehaviour
{
    private float speed = 1000;
    public float rotSpeed = 2;
    public float androidRotSpeed = 5;
    private GameObject endRotation;
    public static bool androidTiltEnabled = true;
    public static InputCmd cmd;
    // Use this for initialization
    void Start()
    {
        endRotation = new GameObject();
#if UNITY_ANDROID
        Input.compensateSensors = true;
        Input.gyro.enabled = true;
        if (!androidTiltEnabled)
        {
            GameObject.Instantiate(Resources.Load("Android_button_l"));
            GameObject.Instantiate(Resources.Load("Android_button_r"));
        }
#endif
    }

    // Update is called once per frame
    void FixedUpdate()
    {
#if UNITY_ANDROID
        if (androidTiltEnabled)
            this.transform.Rotate(0, 0, -Input.gyro.rotationRateUnbiased.z * androidRotSpeed);
        else
        {
            if (cmd == InputCmd.RotateLeft)
            {
                endRotation.transform.Rotate(Vector3.forward, rotSpeed, Space.World);

            }
            if (cmd == InputCmd.RotateRight)
            {
                endRotation.transform.Rotate(Vector3.forward, -rotSpeed, Space.World);
            }

            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, endRotation.transform.rotation, Time.deltaTime * speed);
        }
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
        transform.rotation = Quaternion.Lerp(this.transform.rotation, endRotation.transform.rotation, Time.deltaTime * speed);
#endif
    }
}