using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroidFactory : MonoBehaviour

{
    Color color;
    public float spawnTime = 2;                     // rate of spawning 
    public int astroidCounter;                      // count astroids between spawnTime changes
    public static int totalAstroidNum = 0;          // count astroid per game
    public static int score = 0;                    // managing player's score
    public float spawnDiff;                         // control spawntime changes
    public int accelerationRate;                    // how many astroids untill next spawntime change
    public bool randomSpawn;                        // spawn in a random place on factory else from the middle of it
    public ObjectColor myColor;                     // astroid color
    public float speed;                             // astroids speed from this instance of astroidFactory
    public float degree;                            // angele of launching
    public bool randSize = true;
    public float size =1;                           // the size of the astroid (affects one's speed)
    public bool moveToCenter;

    public bool randomMeteor;
    public MeteorNum myMeteor;                     // type of astroid

    public int activation;                          // activate the factory after X number of astroids has been launched (totalAstroidsNum)
    public int disActivation;                       // disactivate the factory after X number of astroids has been launched (totalAstroidsNum)

    astroidFactory factory;

    //use this to skip levels whule testing game
    public int addToScore = 0;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("addAstroid", 0, spawnTime);
        astroidCounter = 1;
        score = 0;


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
            ScoreManager.score++;
        }
    }

    void addAstroid()
    {
        if (score < activation)
            return;
        if (score > disActivation)
            GameObject.Destroy(gameObject);
        Renderer rd = GetComponent<Renderer>();
        float y1 = transform.position.y - rd.bounds.size.y / 2;
        float y2 = transform.position.y + rd.bounds.size.y / 2;
        Vector2 spawnPoint;
        
        //set spawn point to be random in the range or at the middle of it 
        spawnPoint = (randomSpawn ? new Vector2(transform.position.x, Random.Range(y1, y2)) :
            new Vector2(transform.position.x, (y1 + y2) / 2));
        //= new Vector2(transform.position.x , Random.Range(y1, y2));
        GameObject astroid1 = Instantiate(GetComponent<MeteorType>().GetMeteor(), spawnPoint, Quaternion.identity);

        //set meteor linear movement parameters
        astroid1.GetComponent<LinearMovement>().speed = speed;
        astroid1.GetComponent<LinearMovement>().moveToCenter = moveToCenter;
        astroid1.GetComponent<LinearMovement>().degree = degree;

        //set the meteor size

        float tempSizeFactor = randSize ? Random.Range((size - 0.25f), (size + 0.25f)) : size;
        astroid1.GetComponent<Transform>().localScale *= tempSizeFactor;
        

        

        totalAstroidNum++;
        //update score - size does matters
        score+= Mathf.FloorToInt(tempSizeFactor * 10) ;
        
        //  set meteor Color
        astroid1.GetComponent<ColoredObject>().SetColor(myColor);
        astroidCounter++;
        
        }
}