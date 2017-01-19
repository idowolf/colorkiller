using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rotate : MonoBehaviour
{
    public static int nimrodConstant = 300;
    bool init, cont;
    bool stillActive;
    float OriginalRotAng;
    float OriginalTouchAng;
    float RotationAngle;
    private Quaternion originalRotation;
    Quaternion abc;
    private float angle;
    private float prevAngle;
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
            }
        }
        else
        {
            //transform.rotation = Quaternion.RotateTowards(transform.rotation,transform.rotation.
            cont = false;
            init = false;
        }
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
        prevAngle = angle;
        angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        if (Mathf.Abs(toAngle(prevAngle) - toAngle(angle)) > nimrodConstant * Time.deltaTime)
            Instantiate(Resources.Load("Click1") as GameObject);
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