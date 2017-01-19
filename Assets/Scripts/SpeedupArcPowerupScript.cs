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
    bool activated;
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
        activated = false;
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
        RevertChanges();

        if (stillActive)
            stillActive = false;
        GameObject.Destroy(gameObject);

    }
    private bool changesReverted;

    public void RevertChanges()
    {

        if (!changesReverted)
        {
                if (activated)
                {
                    changesReverted = true;
                    Fire.shootRate *= multiplier;
                }
        }
    }

    void OnDestroy()
    {
        RevertChanges();
    }

}
