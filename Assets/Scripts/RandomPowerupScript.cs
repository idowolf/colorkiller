using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomPowerupScript : Destroyable
{
    public ObjectColor targetColor = ObjectColor.Yellow;
    private float effectLength = 1f;
    private Vector3 oldVelocity;
    public static bool stillActive;
    public static EnemyScript[] enemies;
    public static Dictionary<int, ObjectColor> enemySpeedDict;
    public GameObject[] powerups = new GameObject[6];
    // Use this for initialization
    new void Start()
    {
        base.Start();
    }

    protected override IEnumerator freezeTime()
    {
        base.initiateSelfDestruct = false;
        int num = Random.Range(0, 6);
        GameObject powerup = Instantiate(powerups[num], transform.position, Quaternion.identity);
        powerup.GetComponent<ColoredObject>().SetColor(GetComponent<ColoredObject>().color);
        powerup.GetComponent<Destroyable>().initiateSelfDestruct = true;
        yield return new WaitForSeconds(effectLength);
        GameObject.Destroy(gameObject);

    }


}


