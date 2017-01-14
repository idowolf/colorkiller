using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : Destroyable
{
    public static int EnemiesCount = 0;

    // Use this for initialization
    new void Start()
    {
        base.Start();
    }

    protected override IEnumerator freezeTime()
    {
        yield return new WaitForSeconds(1);
        GameObject.Destroy(gameObject);
    }
}


