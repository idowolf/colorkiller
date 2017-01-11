using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (gameObject.GetComponent<ColoredObject>().color == other.gameObject.GetComponent<ColoredObject>().color)
            initiateSelfDestruct = true;
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

public class SpeedupArcPowerupScript : Destroyable
{
    private Rigidbody2D r2d;
    public float multiplier = 1.5f;
    public float effectLength = 5f;
    private Vector3 oldVelocity;
    public static bool stillActive;
    static Rotate[] enemies;
    public static Rotate spaceship;
    public static float prevRotSpeed;
    public static float prevAndroidRotSpeed;
    static Dictionary<int, ObjectColor> enemySpeedDict;
    // Use this for initialization
    new void Start()
    {
        base.Start();
        r2d = GetComponent<Rigidbody2D>();
    }

    protected override IEnumerator freezeTime()
    {
        initiateSelfDestruct = false;
        bool activated = false;
        if (!stillActive)
        {
            stillActive = true;
             spaceship = FindObjectOfType(typeof(Rotate)) as Rotate;
             prevRotSpeed = spaceship.rotSpeed;
             prevAndroidRotSpeed = spaceship.androidRotSpeed;


        }
        if (spaceship)
        {
            if((spaceship.rotSpeed < prevRotSpeed * 4 && spaceship.androidRotSpeed < prevAndroidRotSpeed * 4)
                || GetComponent<SwitchPowerupScript>()) {
                activated = true;
                spaceship.rotSpeed *= multiplier;
                spaceship.androidRotSpeed *= multiplier;
            }
        }
        Debug.Log(spaceship.rotSpeed);
        yield return new WaitForSeconds(effectLength);
        if (spaceship)
        {
            if (activated) { 
            spaceship.rotSpeed /= multiplier;
            spaceship.androidRotSpeed /= multiplier;
            }
        }
        if (stillActive)
            stillActive = false;
        GameObject.Destroy(gameObject);

    }


}


