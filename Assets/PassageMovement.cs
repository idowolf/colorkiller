using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class PassageMovement : MonoBehaviour
{
    private Rigidbody2D r2d;
    public float degree;
    public bool moveToCenter;
    public float speed;
    private Vector3 oldVelocity;
    public GameObject bullet;
    float leftConstraint = Screen.width;
    float rightConstraint = Screen.width;
    float bottomConstraint = Screen.height;
    float topConstraint = Screen.height;
    float buffer = 1.0f;
    Camera cam;
    float distanceZ;
    bool changing;
    public static string passedArgument = "level2";
    // Use this for initialization
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        Vector3 dest = new Vector3(Mathf.Cos(degree), Mathf.Sin(degree), 0f);
        Vector3 dif = dest - transform.position.normalized;
        if (moveToCenter)
        {
            degree = Mathf.Atan(transform.position.y / transform.position.x) * Mathf.Rad2Deg + 270 + (transform.position.x < 0 ? 180 : 0);
            transform.rotation = Quaternion.Euler(0f, 0f, degree);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 360 - degree + 180);
        }
        r2d.AddForce(transform.up * (-1) * speed * 10, ForceMode2D.Impulse);

        cam = Camera.main;
        distanceZ = Mathf.Abs(cam.transform.position.z + transform.position.z);

        leftConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        rightConstraint = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;
        bottomConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).y;
        topConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, distanceZ)).y;

    }


    void OnBecameInvisible()
    {
        if (!changing)
        {
            StartCoroutine(changeScene());
        }
    }

    // Update is called once per frame
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
            SceneManager.LoadScene(passedArgument);
        }
    }
}














