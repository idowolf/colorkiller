using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : Destroyable
{
    private Rigidbody2D r2d;
    public static int EnemiesCount = 0;
    public int enemyID;

    private Vector3 oldVelocity;
    // Use this for initialization
    new void Start()
    {
        base.Start();
        r2d = GetComponent<Rigidbody2D>();
    }

    protected override IEnumerator freezeTime()
    {
        yield return new WaitForSeconds(1);
        GameObject.Destroy(gameObject);
    }
}


