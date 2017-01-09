using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroidFactory : MonoBehaviour

{
    Color color;
    public GameObject astroid;
    public float spawnTime = 2;
    public int astroidCounter;
    public static int totalAstroidNum = 0;
    public static int score = 0;
    public float spawnDiff;
    public int accelerationRate;
    public bool randomSpawn;
    public ObjectColor myColor;


    public int activation;
    public int disActivation;
    // Use this for initialization
    void Start()
    {

        InvokeRepeating("addAstroid", 0, spawnTime);
        astroidCounter = 1;


    }

    // Update is called once per frame
    void Update()
    {

        if (astroidCounter % accelerationRate == 0)
        {
            //astroidCounter = 1;
            spawnTime -= spawnDiff;
            astroidCounter++;
            score++;
        }
    }

    void addAstroid()
    {
        if (score < activation)
            return;
        if (score > disActivation)
            GameObject.Destroy(gameObject);
        Renderer rd = GetComponent<Renderer>();
        var y1 = transform.position.y - rd.bounds.size.y / 2;
        float y2 = transform.position.y + rd.bounds.size.y / 2;
        Vector2 spawnPoint;
        spawnPoint = (randomSpawn ? new Vector2(transform.position.x, Random.Range(y1, y2)) :
            new Vector2(transform.position.x, (y1 + y2) / 2));
        //= new Vector2(transform.position.x , Random.Range(y1, y2));
        GameObject astroid1 = Instantiate(astroid, spawnPoint, Quaternion.identity);
        totalAstroidNum++;
        score++;
        astroid1.GetComponent<ColoredObject>().SetColor(myColor);
        astroidCounter++;



    }
    
}