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
    public static Fire spaceship;
    public static float prevShootRate;
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
            Instantiate(Resources.Load("PowerupTimer") as GameObject);

            stillActive = true;
            spaceship = FindObjectOfType(typeof(Fire)) as Fire;
            prevShootRate = Fire.shootRate;


        }
        if (spaceship)
        {
            //(spaceship.shootRate < prevShootRate / 8) 
            if (true|| FindObjectOfType<SwitchPowerupScript>())
            {
                activated = true;
                Fire.shootRate /= multiplier;
            }
        }
        yield return new WaitForSeconds(effectLength);
        if (spaceship)
        {
            if (activated)
            {
                Fire.shootRate *= multiplier;
            }
        }
        if (stillActive)
            stillActive = false;
        GameObject.Destroy(gameObject);

    }


}
