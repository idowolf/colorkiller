using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupFactory : MonoBehaviour

{
    Color color;
    public float spawnTime = 2;                     // rate of spawning 
    public int powerupCounter;                      // count astroids between spawnTime changes
    public static int totalPowerupNum = 0;          // count astroid per game
    //public static int score = 0;                    // managing player's score
    public float spawnDiff;                         // control spawntime changes
    public int accelerationRate;                    // how many astroids untill next spawntime change
    public bool randomSpawn;                        // spawn in a random place on factory else from the middle of it
    public ObjectColor myColor;                     // astroid color
    public float speed;                             // astroids speed from this instance of astroidFactory
    public float degree;                            // angele of launching
    public float size =1;                           // the size of the astroid (affects one's speed)
    public bool moveToCenter;

    public PowerupNum myPowerup;                     // type of astroid

    public int activation;                          // activate the factory after X number of astroids has been launched (totalAstroidsNum)
    public int disActivation;                       // disactivate the factory after X number of astroids has been launched (totalAstroidsNum)
    astroidFactory factory;
    // Use this for initialization
    void Start()
    {

        InvokeRepeating("addPowerup", 0, spawnTime);
        powerupCounter = 1;


    }

    // Update is called once per frame
    void Update()
    {

        if (powerupCounter % accelerationRate == 0)
        {
            //astroidCounter = 1;
            spawnTime -= spawnDiff;
            powerupCounter++;
            
        }
    }

    void addPowerup()
    {
        if (astroidFactory.score < activation)
            return;
        if (astroidFactory.score > disActivation)
            GameObject.Destroy(gameObject);
        Renderer rd = GetComponent<Renderer>();
        float y1 = transform.position.y - rd.bounds.size.y / 2;
        float y2 = transform.position.y + rd.bounds.size.y / 2;
        Vector2 spawnPoint;
        
        //set spawn point to be random in the range or at the middle of it 
        spawnPoint = (randomSpawn ? new Vector2(transform.position.x, Random.Range(y1, y2)) :
            new Vector2(transform.position.x, (y1 + y2) / 2));
        //= new Vector2(transform.position.x , Random.Range(y1, y2));
        GameObject astroid1 = Instantiate(GetComponent<PowerupType>().GetPowerup(), spawnPoint, Quaternion.identity);

        //set powerup linear movement parameters
        astroid1.GetComponent<LinearMovement>().speed = speed;
        astroid1.GetComponent<LinearMovement>().moveToCenter = moveToCenter;
        astroid1.GetComponent<LinearMovement>().degree = degree;

        //set the powerup size 

        astroid1.GetComponent<Transform>().localScale *= size;

        

        totalPowerupNum++;
        
        
        //  set powerup Color
        astroid1.GetComponent<ColoredObject>().SetColor(myColor);
        powerupCounter++;
        astroidFactory.score++;
        
        }
}