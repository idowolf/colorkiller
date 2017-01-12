using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    
    private Vector3 mousePos;
    public BulletCtrl bullet;
    private Vector3 dif;
    public float rotationSpeed;
    private bool shoot;
    public AudioClip audio;
    // Use this for initialization
    void Start()
    {
        shoot = false;
    }

    // Update is called once per frame
    void Update()
    {

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector3(mousePos.x, mousePos.y, 0f);
        dif = mousePos - transform.position;
        dif.Normalize();
        float rotZ = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 0f, rotZ + 150), Time.deltaTime * rotationSpeed * 100f);

        if (Input.GetKeyUp(KeyCode.Mouse0))
            shoot = true;
        // When the spacebar is pressed 
        if (shoot && Quaternion.Angle(transform.rotation, Quaternion.Euler(0f, 0f, rotZ + 150)) < 1)
        {
            // Create a new bullet at “transform.position” 
            // Which is the current position of the ship
            //Quaternion.identity = add the bullet with no rotation
            float x = 4.25576412f * Mathf.Cos((rotZ + 180) * Mathf.Deg2Rad);
            float y = 4.25576412f * Mathf.Sin((rotZ + 180) * Mathf.Deg2Rad);
            BulletCtrl instBullet = GameObject.Instantiate(bullet, offsetPosition(0, 0), Quaternion.identity);
            instBullet.xFinger = x;
            instBullet.yFinger = y; 
            instBullet.bulletSpeed = 20;
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            shoot = false;
        }


    }

    Vector3 offsetPosition(float xOffset = 0, float yOffset = 0, float zOffset = 0)
    {
        Vector3 pos = transform.position;
        return new Vector3(pos.x - xOffset, pos.y - yOffset, pos.z - zOffset);
    }

}
