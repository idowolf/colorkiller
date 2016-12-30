using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    
    private Vector3 mousePos;
    public BulletCtrl bullet;
    public Vector3 dif;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector3(mousePos.x, mousePos.y, 0f);
        dif = mousePos - transform.position;
        dif.Normalize();
        float rotZ = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 120);


        // When the spacebar is pressed 
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Create a new bullet at “transform.position” 
            // Which is the current position of the ship
            //Quaternion.identity = add the bullet with no rotation

            float x = 4.25576412f * Mathf.Cos((rotZ + 180) * Mathf.Deg2Rad);
            float y = 4.25576412f * Mathf.Sin((rotZ + 180) * Mathf.Deg2Rad);
            BulletCtrl instBullet = GameObject.Instantiate(bullet, offsetPosition(0, 0), Quaternion.identity);
            instBullet.xFinger = x;
            instBullet.yFinger = y;
            Debug.Log("mousePos" + mousePos);
            Debug.Log("angle=" + rotZ);
            Debug.Log("x=" + x);
            Debug.Log("y=" + y);
            instBullet.bulletSpeed = 20;
        }


    }

    Vector3 offsetPosition(float xOffset = 0, float yOffset = 0, float zOffset = 0)
    {
        Vector3 pos = transform.position;
        return new Vector3(pos.x - xOffset, pos.y - yOffset, pos.z - zOffset);
    }

}
