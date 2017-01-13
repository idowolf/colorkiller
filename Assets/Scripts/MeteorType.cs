using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MeteorNum
{
    One,
    Two,
    Three,
    Four,
    
}

public class MeteorType : MonoBehaviour {

    astroidFactory factory;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*
    public void SetMeteorType(MeteorNum meteor , bool isRand) {
        factory = gameObject.GetComponent<astroidFactory>();
        if (isRand)
        {
            float temp = Random.Range(1, 5.99f);
            int tempInt = Mathf.FloorToInt(temp);
            switch (tempInt)
            {
                case (1):
                    meteor = MeteorNum.One;
                    break;
                case (2):
                    meteor = MeteorNum.Two;
                    break;
                case (3):
                    meteor = MeteorNum.Three;
                    break;
                case (4):
                    meteor = MeteorNum.Four;
                    break;
                case (5):
                    meteor = MeteorNum.Five;
                    break;
               
            }
            factory.astroid = meteor;
        }
    } */
}
