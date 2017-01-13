using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public static int PowerupsCount = 0;
    public int powerupID;
    private Rigidbody2D r2d;
    private Vector3 oldVelocity;

    public bool initiateSelfDestruct;
    public void Start()
    {
        r2d = GetComponent<Rigidbody2D>();

        powerupID = PowerupsCount;
        PowerupsCount++;
    }

    void Update()
    {
        oldVelocity = r2d.velocity;
        if (initiateSelfDestruct)
        {
            BulletCtrl.FakeDestroy(gameObject);
            StartCoroutine(freezeTime());

        }
    }

    protected virtual IEnumerator freezeTime()
    {
        return null;
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
            initiateSelfDestruct = true;
    }
}
