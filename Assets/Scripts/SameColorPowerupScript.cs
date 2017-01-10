using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SameColorPowerupScript : Destroyable
{
    private Rigidbody2D r2d;
    public ObjectColor targetColor = ObjectColor.Yellow;
    public float effectLength = 5f;
    private Vector3 oldVelocity;
    private bool ready;
    public static bool stillActive;
    static EnemyScript[] enemies;
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
        if (!stillActive)
        {
            stillActive = true;
            enemies = FindObjectsOfType(typeof(EnemyScript)) as EnemyScript[];

            enemySpeedDict = new Dictionary<int, ObjectColor>();

            foreach (EnemyScript enemy in enemies)
            {
                if (enemy)
                {
                    enemySpeedDict.Add(enemy.enemyID, enemy.gameObject.GetComponent<ColoredObject>().color);
                    enemy.gameObject.GetComponent<ColoredObject>().SetColor(targetColor, false); // TODO
                }
            }
        }

        yield return new WaitForSeconds(effectLength);
        foreach (EnemyScript enemy in enemies)
        {
            if (enemy)
                enemy.gameObject.GetComponent<ColoredObject>().SetColor(enemySpeedDict[enemy.enemyID]); // TODO
        }
        if (stillActive)
            stillActive = false;
        GameObject.Destroy(gameObject);

    }


}


