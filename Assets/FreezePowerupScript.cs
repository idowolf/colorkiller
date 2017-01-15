using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FreezePowerupScript : Destroyable
{
    public float effectLength = 5f;
    public static bool stillActive;
    public static Destroyable[] powerups;
    public static Dictionary<int, Vector3> powerupSpeedDict;
    // Use this for initialization
    new void Start()
    {
        base.Start();
    }

    protected override IEnumerator freezeTime()
    {
        if (!stillActive)
        {
            Instantiate(Resources.Load("PowerupTimer") as GameObject);

            stillActive = true;
            powerups = FindObjectsOfType(typeof(Destroyable)) as Destroyable[];

            powerupSpeedDict = new Dictionary<int, Vector3>();
            foreach (Destroyable powerup in powerups)
            {
                if (powerup)
                {
                    powerupSpeedDict.Add(powerup.powerupID, powerup.gameObject.GetComponent<Rigidbody2D>().velocity);
                    powerup.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                }
            }
        }

        yield return new WaitForSeconds(effectLength);
        foreach (Destroyable powerup in powerups)
        {
            if(powerup)
                powerup.gameObject.GetComponent<Rigidbody2D>().velocity = powerupSpeedDict[powerup.powerupID];
        }
        if (stillActive)
            stillActive = false;
        GameObject.Destroy(gameObject);

    }


}


