using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MonoBehaviour {
    private Rigidbody2D r2d;
    public float degree;
    public float speed;
    private Vector3 oldVelocity;
    public GameObject bullet;
    // Use this for initialization
    void Start () {
        r2d = GetComponent<Rigidbody2D>();
        Vector3 dest = new Vector3(Mathf.Cos(degree), Mathf.Sin(degree), 0f);
        Vector3 dif = dest - transform.position.normalized;
        transform.rotation = Quaternion.Euler(0f, 0f, 360 - degree);
        r2d.AddForce(transform.up * speed * 10, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update () {
        oldVelocity = r2d.velocity;
    }
}
