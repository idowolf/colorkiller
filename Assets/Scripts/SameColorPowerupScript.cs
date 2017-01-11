using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SameColorPowerupScript : Destroyable
{
    private Rigidbody2D r2d;
    public ObjectColor targetColor = ObjectColor.Yellow;
    public float effectLength = 5f;
    private Vector3 oldVelocity;
    public static bool stillActive;
    public static EnemyScript[] enemies;
    public static Dictionary<int, ObjectColor> enemySpeedDict;
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
            enemies = FindObjectsOfType(typeof(EnemyScript)) as EnemyScript[];

            enemySpeedDict = new Dictionary<int, ObjectColor>();

            foreach (EnemyScript enemy in enemies)
            {
                if (enemy)
                {
                    enemySpeedDict.Add(enemy.enemyID, enemy.gameObject.GetComponent<ColoredObject>().color);
                    enemy.gameObject.GetComponent<ColoredObject>().SetColor(targetColor, false); // TODO
                }
            }
        }

        yield return new WaitForSeconds(effectLength);
        foreach (EnemyScript enemy in enemies)
        {
            if (enemy)
                enemy.gameObject.GetComponent<ColoredObject>().SetColor(enemySpeedDict[enemy.enemyID]); // TODO
        }
        if (stillActive)
            stillActive = false;
        GameObject.Destroy(gameObject);

    }


}


