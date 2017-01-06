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
    SpriteRenderer ren;
    public string sceneName;
    private Vector3 oldVelocity;

    // Use this for initialization
    void Start()
    {
        ren = gameObject.GetComponent<SpriteRenderer>();
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
        // get the point of contact
        ContactPoint2D contact = other.contacts[0];

        // reflect our old velocity off the contact point's normal vector
        Vector3 reflectedVelocity = Vector3.Reflect(oldVelocity, contact.normal);

        // assign the reflected velocity back to the rigidbody
        r2d.velocity = reflectedVelocity;
        // rotate the object by the same ammount we changed its velocity
        Quaternion rotation = Quaternion.FromToRotation(oldVelocity, reflectedVelocity);
        transform.rotation = rotation * transform.rotation;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("pink"))
        {
            ren.color = new Color(1f, 0f, 0.502f); // pink
            gameObject.name = "pink";
        }
        if (other.gameObject.name.Equals("purple"))
        {
            ren.color = new Color(0.549f, 0.075f, 0.984f); // purple
            gameObject.name = "purple";
        }
        if (other.gameObject.name.Equals("turkiz"))
        {
            ren.color = new Color(0.208f, 0.886f, 0.953f, 1.000f); // turkiz
            gameObject.name = "turkiz";
        }
        if (other.gameObject.name.Equals("yellow"))
        {
            ren.color = new Color(0.965f, 0.875f, 0.055f, 1.000f); // yellow
            gameObject.name = "yellow";
        }
        if (other.gameObject.name.Equals("StartGameButton"))
            SceneManager.LoadScene(sceneName);
    }

}
