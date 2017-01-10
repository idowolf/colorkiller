using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroyable : MonoBehaviour
{
    public static int PowerupsCount = 0;
    public int powerupID;
    public void Start()
    {
        powerupID = PowerupsCount;
        PowerupsCount++;
    }

}

public class SpeedupArcPowerupScript : Destroyable
{
    private Rigidbody2D r2d;
    public float multiplier = 1.5f;
    public float effectLength = 5f;
    private Vector3 oldVelocity;
    private bool ready;
    public static bool stillActive;
    static Rotate[] enemies;
    static Dictionary<int, ObjectColor> enemySpeedDict;
    // Use this for initialization
    new void Start()
    {
        base.Start();
        r2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (ready)
        {
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            StartCoroutine(freezeTime());

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
            ready = true;
    }
    
    public IEnumerator freezeTime()
    {
        Rotate spaceship = FindObjectOfType(typeof(Rotate)) as Rotate;
        float prevRotSpeed = spaceship.rotSpeed;
        float prevAndroidRotSpeed = spaceship.androidRotSpeed;

        if (!stillActive)
        {
            stillActive = true;

            enemySpeedDict = new Dictionary<int, ObjectColor>();

            if (spaceship)
            {
                spaceship.rotSpeed*=multiplier;
                spaceship.androidRotSpeed *= multiplier;
            }
        }

        yield return new WaitForSeconds(effectLength);
        Debug.Log(spaceship);
        if (spaceship)
        {
            spaceship.rotSpeed = prevRotSpeed;
            spaceship.androidRotSpeed = prevAndroidRotSpeed;
        }
        if (stillActive)
            stillActive = false;
        GameObject.Destroy(gameObject);

    }


}


