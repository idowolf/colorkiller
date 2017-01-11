﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FreezePowerupScript : Destroyable
{
    private Rigidbody2D r2d;
    public float effectLength = 5f;
    private Vector3 oldVelocity;
    public static bool stillActive;
    public static Destroyable[] powerups;
    public static Dictionary<int, Vector3> powerupSpeedDict;
    // Use this for initialization
    new void Start()
    {
        base.Start();
        r2d = GetComponent<Rigidbody2D>();
    }

    protected override IEnumerator freezeTime()
    {
        if (!stillActive)
        {
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

