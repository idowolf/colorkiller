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
    bool init, cont;
    bool stillActive;
    float OriginalRotAng;
    float OriginalTouchAng;
    float RotationAngle;
    private Quaternion originalRotation;
    Quaternion abc;
    private float angle;
    private float time;
    Vector3 rotationLast; //The value of the rotation at the previous update
    Vector3 rotationDelta; //The difference in rotation between now and the previous update
    private float startAngle = 0;
    Quaternion finalRot;
    public void Start()
    {
        abc = this.transform.rotation;
        rotationLast = transform.rotation.eulerAngles;

    }
    void Update()
    {
        //Update both variables, so they're accurate every frame.
        rotationDelta = transform.rotation.eulerAngles - rotationLast;
        rotationLast = transform.rotation.eulerAngles;

        //Debug.Log(angle + " : " + backAngle(toAngle(angle)));
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            InputIsDown();
            init = true;
        }

        else if (Input.GetKey(KeyCode.Mouse0))
        {
            InputIsHeld();
            if (init)
            {
                init = false;
                cont = true;
                StartCoroutine(Click());
            }
        }
        else
        {
            //transform.rotation = Quaternion.RotateTowards(transform.rotation,transform.rotation.
            cont = false;
            init = false;
        }
        Debug.Log(1 / Mathf.Abs(angularVelocity.z));

    }
    public Vector3 angularVelocity
    {
        get
        {
            return rotationDelta;
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

    public float toAngle(float angle)
    {
        float n1 = 180 - angle;
        if (n1 >= 90 && n1 <= 180)
            return n1 - 90;
        if (n1 >= 0 && n1 <= 90)
            return n1 + 270;
        return Mathf.Abs(angle) + 90;

    }

    public float backAngle(float angle)
    {
        float n1 = 0;

        if (angle >= 270 && angle <= 360)
        {
            n1 = angle + 90;
            n1 = 180 - n1;
        }
        else if (n1 >= 0 && n1 <= 90)
        {
            n1 = angle + 270;
            n1 = 180 - n1;
        }
        else if (n1 >= 90 && n1 <= 180)
            n1 = 90 - angle;

        return n1;
    }

    public float diffAngles(float transAngle, float destAngle)
    {
        return 0;
    }

    public IEnumerator Click()
    {
        yield return new WaitForSeconds(Mathf.Abs(angularVelocity.z) < 0.05f ? 0.2f : 1 / Mathf.Abs(angularVelocity.z));

        if (cont)
        {
            //stillActive = true;
            Instantiate(Resources.Load("Click1") as GameObject);

        }
        StartCoroutine(Click());
    }
}