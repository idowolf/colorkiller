using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farticle : MonoBehaviour {

    private ParticleSystem Particale;
    // Use this for initialization

    
    void Start ()
    {
        Particale = Resources.Load("Ex_white") as ParticleSystem;
	}

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        //Particale = Resources.Load<ParticleSystem>("Ex_" + gameObject.GetComponent<ColoredObject>().color.ToString().ToLower());
        //bool flg1 = BulletCtrl.isDestroyable(gameObject) && gameObject.GetComponent<ColoredObject>().color == other.gameObject.GetComponent<ColoredObject>().color;
        //bool flg2 = BulletCtrl.isDestroyable(gameObject) && other.GetComponent<SpaceshipScript>();
        //bool flg3 = GetComponent<SpaceshipScript>() && other.GetComponent<EnemyScript>();
        //if (flg1 || flg2 || flg3)
        // {
        //    InitParticle();
        // }
        CallMeMaybe(other.gameObject);
     }
    
    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    CallMeMaybe(other.gameObject);
    //}
    void CallMeMaybe(GameObject other)
    {
        Particale = Resources.Load<ParticleSystem>("Ex_" + GetComponent<ColoredObject>().color.ToString().ToLower());
        bool flg1 = BulletCtrl.isDestroyable(gameObject) && GetComponent<ColoredObject>().color == other.gameObject.GetComponent<ColoredObject>().color;
        bool flg2 = BulletCtrl.isDestroyable(gameObject) && other.GetComponent<SpaceshipScript>();
        bool flg3 = GetComponent<SpaceshipScript>() && other.GetComponent<EnemyScript>();
        if (flg1 || flg2 || flg3)
        {
            InitParticle();
        }
    }
    void InitParticle()
    {
        ParticleSystem ps = (ParticleSystem)Instantiate(Particale, transform.position, Quaternion.identity);
        Destroy(ps, 1f);

        //ParticleSystem m_System = GetComponent<ParticleSystem>();
        //ParticleSystem.MainModule main = m_System.main;

        //bool minMaxCurve = main.loop; //Get Size

        //minMaxCurve = false; //Modify Size
        //main.loop = minMaxCurve; //Assign the modified startSize back


    }
}
