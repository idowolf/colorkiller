using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squareFactoryScript : MonoBehaviour {

    public GameObject enemy;
    public float spawnTime = 3;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("addEnemy", 0, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void addEnemy()
    {
        Renderer rd = GetComponent<Renderer>();
        var y1 = transform.position.y - rd.bounds.size.y / 2;
        var y2 = transform.position.y + rd.bounds.size.y / 2;
        var spawnPoint = new Vector2( transform.position.x , Random.Range(y1, y2));
        Instantiate(enemy, spawnPoint, Quaternion.identity);

    }
}
