//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//public enum InputCmd
//{
//    DoNone,
//    RotateLeft,
//    RotateRight
//}
//public class Rotate : MonoBehaviour
//{
//    private float speed = 1000;
//    public float rotSpeed = 2;
//    public float androidRotSpeed = 5;
//    private GameObject endRotation;
//    public static bool androidTiltEnabled = true;
//    public static InputCmd cmd;
//    // Use this for initialization
//    void Start()
//    {
//        endRotation = new GameObject();
//#if UNITY_ANDROID
//        Input.compensateSensors = true;
//        Input.gyro.enabled = true;
//        if (!androidTiltEnabled)
//        {
//            GameObject.Instantiate(Resources.Load("Android_button_l"));
//            GameObject.Instantiate(Resources.Load("Android_button_r"));
//        }
//#endif
//    }

//    // Update is called once per frame
//    void FixedUpdate()
//    {
//#if UNITY_ANDROID
//        if (androidTiltEnabled)
//            this.transform.Rotate(0, 0, -Input.gyro.rotationRateUnbiased.z * androidRotSpeed);
//        else
//        {
//            if (cmd == InputCmd.RotateLeft)
//            {
//                endRotation.transform.Rotate(Vector3.forward, rotSpeed, Space.World);

//            }
//            if (cmd == InputCmd.RotateRight)
//            {
//                endRotation.transform.Rotate(Vector3.forward, -rotSpeed, Space.World);
//            }

//            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, endRotation.transform.rotation, Time.deltaTime * speed);
//        }
//#endif
//#if UNITY_EDITOR
//        if (Input.GetKey(KeyCode.LeftArrow))
//        {
//            endRotation.transform.Rotate(Vector3.forward, rotSpeed, Space.World);
//        }
//        if (Input.GetKey(KeyCode.RightArrow))
//        {
//            endRotation.transform.Rotate(Vector3.forward, -rotSpeed, Space.World);
//        }
//        transform.rotation = Quaternion.Lerp(this.transform.rotation, endRotation.transform.rotation, Time.deltaTime * speed);
//#endif
//    }
//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rotate : MonoBehaviour
{

    float OriginalRotAng;
    float OriginalTouchAng;
    float RotationAngle;
    private Quaternion originalRotation;
    Quaternion abc;
    private float angle;
    private float startAngle = 0;
    Quaternion finalRot;
    public void Start()
    {
        abc = this.transform.rotation;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            InputIsDown();

        else if (Input.GetKey(KeyCode.Mouse0))
            InputIsHeld();
        else
        {
            transform.rotation = abc;
        }

    }

    public void InputIsDown()
    {
        originalRotation = abc;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 vector = Input.mousePosition - screenPos;
        startAngle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;

    }

    public void InputIsHeld()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 vector = Input.mousePosition - screenPos;
        angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        Quaternion newRotation = Quaternion.AngleAxis(angle - startAngle, this.transform.forward);
        newRotation.y = 0; //see comment from above 
        newRotation.eulerAngles = new Vector3(0, 0, newRotation.eulerAngles.z);
        this.transform.rotation = originalRotation * newRotation;
        abc = this.transform.rotation;
    }

}