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
    public static Vector3 prevScale;
    public Vector3 myVector;
    // Use this for initialization
    new void Start()
    {
        base.Start();
    }

    protected override IEnumerator freezeTime()
    {

        if (!stillActive)
        {
            
            stillActive = true;
            spaceship = FindObjectOfType(typeof(SpaceshipScript)) as SpaceshipScript;
            prevScale = spaceship.gameObject.transform.localScale;



        }
        if (spaceship)
        {
            myVector = new Vector3(prevScale.x * multiplier, prevScale.y * multiplier, prevScale.z * multiplier);
            spaceship.gameObject.transform.localScale = myVector;
        }
        yield return new WaitForSeconds(effectLength);
        if (spaceship.gameObject.transform.localScale.Equals(myVector)) { 
            spaceship.gameObject.transform.localScale = prevScale;
        if (stillActive)
        { 
            stillActive = false;
        }
        }
        GameObject.Destroy(gameObject);

    }


}


