using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearTowardsMIddle : MonoBehaviour
{
    private Rigidbody2D r2d;
    float degree;
    public float speed;
    private Vector3 oldVelocity;
    public GameObject bullet;
    // Use this for initialization
    void Start()
    {
        degree = 0;
        r2d = GetComponent<Rigidbody2D>();
        Vector3 dest = new Vector3(0f, 0f, 0f);
        Vector3 dif = dest - transform.position.normalized;
        transform.rotation = Quaternion.Euler(dif);
        r2d.AddForce(new Vector2(0f, 0f) * speed * 10, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        oldVelocity = r2d.velocity;
    }
}
