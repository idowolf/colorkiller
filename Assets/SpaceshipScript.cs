using System.Collections;
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
            Debug.Log("Works1.5");
            BulletCtrl.FakeDestroy(gameObject);
            StartCoroutine(selfDestruct());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        bool flg3 = other.GetComponent<EnemyScript>();
        if (flg3)
        {
            Debug.Log("Works1");
            initiateSelfDestruct = true;

        }
    }

    public IEnumerator selfDestruct()
    {
        Debug.Log("Works2");
        GameObject.Find("ThrustEffect").GetComponent<ParticleSystem>().Stop();
        yield return new WaitForSeconds(1);
        Debug.Log("Works3");
        SceneManager.LoadScene("GameOver");
        GameObject.Destroy(gameObject);
    }
}
