using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResizeSpaceshipPowerupScript : Destroyable
{
    public float multiplier = 0.5f;
    public float effectLength = 5f;
    public static bool stillActive;
    public static SpaceshipScript spaceship;
    public static BulletCtrl bullet;
    public static Vector3 prevScale;
    public static Vector3 bulletPrevScale;
    public Vector3 myVector;
    public Vector3 myBulletVector;
    // Use this for initialization
    new void Start()
    {
        base.Start();
    }

    void update()
    {
        Debug.Log(GameObject.FindObjectsOfType<BulletCtrl>());
        if (true) {
            foreach (BulletCtrl bullet in GameObject.FindObjectsOfType<BulletCtrl>())
            Debug.Log("stam ido");
            bullet.gameObject.transform.localScale = myBulletVector;
        }

    }
    protected override IEnumerator freezeTime()
    {

        if (!stillActive)
        {
            
            stillActive = true;
            spaceship = FindObjectOfType(typeof(SpaceshipScript)) as SpaceshipScript;
            prevScale = spaceship.gameObject.transform.localScale;
            bullet = FindObjectOfType(typeof(BulletCtrl)) as BulletCtrl;
            bulletPrevScale = bullet.gameObject.transform.localScale;




        }
        if (spaceship)
        {
            myVector = new Vector3(prevScale.x * multiplier, prevScale.y * multiplier, prevScale.z * multiplier);
            spaceship.gameObject.transform.localScale = myVector;
            myBulletVector = new Vector3(bulletPrevScale.x, bulletPrevScale.y, bulletPrevScale.z) * multiplier;
            
        }
        yield return new WaitForSeconds(effectLength);
        if (spaceship.gameObject.transform.localScale.Equals(myVector)) { 
            spaceship.gameObject.transform.localScale = prevScale;
            bullet.gameObject.transform.localScale = bulletPrevScale;
        if (stillActive)
        { 
            stillActive = false;
        }
        }
        GameObject.Destroy(gameObject);

    }


}


