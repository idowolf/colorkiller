using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpeedupArcPowerupScript : Destroyable
{
    public float multiplier = 3f;
    public float effectLength = 5f;
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


