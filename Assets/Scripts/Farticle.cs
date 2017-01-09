using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farticle : MonoBehaviour {

    private ParticleSystem Particale;
    // Use this for initialization

    
    void Start ()
    {
	}

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        Particale = Resources.Load<ParticleSystem>("Ex_" + gameObject.GetComponent<ColoredObject>().color.ToString().ToLower());

        if (gameObject.GetComponent<ColoredObject>().color == other.gameObject.GetComponent<ColoredObject>().color)
         {
            InitParticle();
         }
     }
    
    void InitParticle()
    {
        ParticleSystem ps = (ParticleSystem)Instantiate(Particale, transform.position, Quaternion.identity);
        Destroy(ps, 1);
    }
}
