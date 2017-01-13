﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceshipScript : MonoBehaviour {
    private bool initiateSelfDestruct;

    // Use this for initialization
    void Start () {
		
	}

    void FixedUpdate()
    {
        //transform.position += transform.up * bulletSpeed * Time.deltaTime;
        if (initiateSelfDestruct)
        {
            BulletCtrl.FakeDestroy(gameObject);
            StartCoroutine(selfDestruct());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        bool flg3 = GetComponent<SpaceshipScript>() && other.GetComponent<EnemyScript>();
        if (flg3)
        {
            initiateSelfDestruct = true;

        }
    }

    public IEnumerator selfDestruct()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Scenes/GameOver");
        GameObject.Destroy(gameObject);
    }
}
