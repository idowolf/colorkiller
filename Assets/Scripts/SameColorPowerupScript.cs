using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SameColorPowerupScript : Destroyable
{
    private ObjectColor targetColor;
    public float effectLength = 5f;
    public static bool stillActive;
    public static EnemyScript[] enemies;
    public static Dictionary<int, ObjectColor> enemySpeedDict;
    // Use this for initialization
    new void Start()
    {
        base.Start();
        targetColor = GetComponent<ColoredObject>().color;
    }

    protected override IEnumerator freezeTime()
    {
        if (!stillActive)
        {
            Instantiate(Resources.Load("PowerupTimer") as GameObject);

            stillActive = true;
            enemies = FindObjectsOfType(typeof(EnemyScript)) as EnemyScript[];

            enemySpeedDict = new Dictionary<int, ObjectColor>();

            foreach (EnemyScript enemy in enemies)
            {
                if (enemy)
                {
                    enemySpeedDict.Add(enemy.powerupID, enemy.gameObject.GetComponent<ColoredObject>().color);
                    enemy.gameObject.GetComponent<ColoredObject>().SetColor(targetColor, false); // TODO
                }
            }
        }

        yield return new WaitForSeconds(effectLength);
        foreach (EnemyScript enemy in enemies)
        {
            if (enemy)
                enemy.gameObject.GetComponent<ColoredObject>().SetColor(enemySpeedDict[enemy.powerupID]); // TODO
        }
        if (stillActive)
            stillActive = false;
        GameObject.Destroy(gameObject);

    }


}


