﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : Destroyable
{
    private Rigidbody2D r2d;
    public static int EnemiesCount = 0;
    public int enemyID;

    private Vector3 oldVelocity;
    private float animationTime;
    private bool initiateSelfDestruct;
    // Use this for initialization
    new void Start()
    {
        base.Start();
        animationTime = 0;
        r2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //transform.position += transform.up * bulletSpeed * Time.deltaTime;
        oldVelocity = r2d.velocity;
        if (initiateSelfDestruct)
        {
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            StartCoroutine(selfDestruct());
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
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
        bool flg1 = BulletCtrl.isDestroyable(gameObject) && gameObject.GetComponent<ColoredObject>().color == other.gameObject.GetComponent<ColoredObject>().color;
        bool flg2 = BulletCtrl.isDestroyable(gameObject) && other.GetComponent<SpaceshipScript>();
        bool flg3 = GetComponent<SpaceshipScript>() && other.GetComponent<EnemyScript>();
        if (flg1 || flg2 || flg3)
        {
            initiateSelfDestruct = true;
        }
    }

    public IEnumerator selfDestruct()
    {
        yield return new WaitForSeconds(1);
        GameObject.Destroy(gameObject);
    }
}


