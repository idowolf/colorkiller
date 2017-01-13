using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

    public AudioClip audio;

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.GetComponent<FireParticleEffect>())
        {

            bool flg1 = BulletCtrl.isDestroyable(gameObject) && gameObject.GetComponent<ColoredObject>().color == other.gameObject.GetComponent<ColoredObject>().color;
            bool flg2 = other.GetComponent<SpaceshipScript>();

            bool flg3 = GetComponent<SpaceshipScript>() && other.GetComponent<EnemyScript>();
            if (flg1 || flg2 || flg3)
            {
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
            }
        }
    }
}
