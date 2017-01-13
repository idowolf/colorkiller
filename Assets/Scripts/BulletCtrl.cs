using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletCtrl : MonoBehaviour
{
    public int speed = -6;
    private Rigidbody2D r2d;
    public Vector3 mousePos;
    public float bulletSpeed;
    public float xFinger;
    public float yFinger;
    private Vector3 oldVelocity;
    public AudioClip audio;


    // Use this for initialization
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector3(mousePos.x, mousePos.y, 0f);
        Vector3 dif = mousePos - transform.position;
        dif.Normalize();
        float rotZ = Mathf.Atan2(yFinger, xFinger) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 90);
        r2d.velocity = transform.up * bulletSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position += transform.up * bulletSpeed * Time.deltaTime;
        oldVelocity = r2d.velocity;
    }

    // Function called when the object goes out of the screen
    void OnBecameInvisible()
    {
        // Destroy the bullet 
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isDestroyable(other.gameObject)) { 
        if (other.GetComponent<ColoredObject>() != null)
            gameObject.GetComponent<ColoredObject>().SetColor(other.GetComponent<ColoredObject>().color);
        }
        else
        {
            if (gameObject.GetComponent<ColoredObject>().color == other.gameObject.GetComponent<ColoredObject>().color)
            {
                Destroy(gameObject);
                return;
            }
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            // get the point of contact

            // reflect our old velocity off the contact point's normal vector
            Vector3 reflectedVelocity = Vector3.Reflect(oldVelocity, other.transform.position.normalized);

            // assign the reflected velocity back tohe rigidbody
            r2d.velocity = reflectedVelocity;
            // rotate the object by the same ammount we changed its velocity
            Quaternion rotation = Quaternion.FromToRotation(oldVelocity, reflectedVelocity);
            transform.rotation = rotation * transform.rotation;
        }
    }

    public static bool isDestroyable(GameObject obj)
    {
        return obj.GetComponent<Destroyable>();
    }

    public static void FakeDestroy(GameObject obj)
    {
        obj.transform.localScale = new Vector3(0, 0, 0);
        obj.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        obj.GetComponent<Collider2D>().enabled = false;
    }
}
