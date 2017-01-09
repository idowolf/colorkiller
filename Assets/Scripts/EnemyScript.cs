using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour {
    private Rigidbody2D r2d;

    private Vector3 oldVelocity;
    private float animationTime;
    private bool endGame;
    // Use this for initialization
    void Start()
    {
        endGame = false;
        animationTime = 0;
        r2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //transform.position += transform.up * bulletSpeed * Time.deltaTime;
        oldVelocity = r2d.velocity;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (endGame)
        {
            animationTime += Time.deltaTime;
            Debug.Log(animationTime);
            if (animationTime > GetComponent<Farticle>().Particale.main.duration) { 
                SceneManager.LoadScene("GameOver");
                Destroy(gameObject);
            }
        }
        if(other.gameObject.GetComponent<BulletCtrl>() != null) // other is a bullet
            
        {
            // bullet is same color as enemy
            if (gameObject.GetComponent<ColoredObject>().color == other.gameObject.GetComponent<ColoredObject>().color)
            {
                Destroy(gameObject);
                Destroy(other.gameObject);

            }
            // otherwise, do nothing
        }
        // other is not a bullet: bounce!

        // get the point of contact
        ContactPoint2D contact = other.contacts[0];

        // reflect our old velocity off the contact point's normal vector
        Vector3 reflectedVelocity = Vector3.Reflect(oldVelocity, contact.normal);

        // assign the reflected velocity back tohe rigidbody
        r2d.velocity = reflectedVelocity;
        // rotate the object by the same ammount we changed its velocity
        Quaternion rotation = Quaternion.FromToRotation(oldVelocity, reflectedVelocity);
        transform.rotation = rotation * transform.rotation;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<SpaceshipScript>() != null) { 
            endGame = true;
        }
        Debug.Log(endGame);
        Destroy(other.gameObject);
        if (!endGame)
            Destroy(gameObject);

    }
}


