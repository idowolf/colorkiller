using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FreezePowerupScript : Destroyable
{
    private Rigidbody2D r2d;
    public float effectLength = 5f;
    private Vector3 oldVelocity;
    private bool ready;
    public static bool stillActive;
    static Destroyable[] powerups;
    static EnemyScript[] enemies;
    static Dictionary<int, Vector3> powerupSpeedDict;
    static Dictionary<int, Vector3> enemySpeedDict;
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
        if (!stillActive)
        {
            stillActive = true;
            powerups = FindObjectsOfType(typeof(Destroyable)) as Destroyable[];
            enemies = FindObjectsOfType(typeof(EnemyScript)) as EnemyScript[];

            powerupSpeedDict = new Dictionary<int, Vector3>();
            enemySpeedDict = new Dictionary<int, Vector3>();
            foreach (Destroyable powerup in powerups)
            {
                if (powerup)
                {
                    powerupSpeedDict.Add(powerup.powerupID, powerup.gameObject.GetComponent<Rigidbody2D>().velocity);
                    powerup.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                }
            }

            foreach (EnemyScript enemy in enemies)
            {
                if (enemy)
                {
                    enemySpeedDict.Add(enemy.enemyID, enemy.gameObject.GetComponent<Rigidbody2D>().velocity);
                    enemy.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                }
            }
        }

        yield return new WaitForSeconds(effectLength);
        foreach (Destroyable powerup in powerups)
        {
            if(powerup)
                powerup.gameObject.GetComponent<Rigidbody2D>().velocity = powerupSpeedDict[powerup.powerupID];
        }
        foreach (EnemyScript enemy in enemies)
        {
            if (enemy)
                enemy.gameObject.GetComponent<Rigidbody2D>().velocity = enemySpeedDict[enemy.enemyID];
        }
        if (stillActive)
            stillActive = false;
        GameObject.Destroy(gameObject);

    }


}


