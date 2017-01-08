using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroidFactory : MonoBehaviour

{
    Color color;
    public GameObject astroid;
    public float spawnTime = 2;
    public int astroidCounter;
    // Use this for initialization
    void Start()
    {

        InvokeRepeating("addAstroid", 0, spawnTime);
        astroidCounter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (astroidCounter % 5 == 0) {
            astroidCounter = 1;
            spawnTime-= 0.2f; }
    }
    void addAstroid()
    {
        Renderer rd = GetComponent<Renderer>();
        var y1 = transform.position.y - rd.bounds.size.y / 2;
        var y2 = transform.position.y + rd.bounds.size.y / 2;
        var spawnPoint = new Vector2(Random.Range(y1-5, y2+25), transform.position.x+24);
        GameObject astroid1 = Instantiate(astroid, spawnPoint, Quaternion.identity);
        Color thisColor;
        astroid1.GetComponent<ColoredObject>().SetColor();
        astroidCounter++;
        

    }
}