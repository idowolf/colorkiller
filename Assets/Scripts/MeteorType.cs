using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MeteorNum
{
    One,
    Two,
    Three,
    Four,
    Five,
    Rand,
}

public class MeteorType : MonoBehaviour {

    astroidFactory factory;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void SetMeteorNum(MeteorNum meteor , bool isRand) {
        factory = gameObject.GetComponent<astroidFactory>();
        if (isRandom)
        {
            float temp = Random.Range(1, 5);
            int tempInt = (int)temp;
            switch (tempInt)
            {
                case (1):
                    meteor = MeteorNum.One;
                case (2):
                    meteor = MeteorNum.Two;
                case (3):
                    meteor = MeteorNum.Three;
                case (4):
                    meteor = MeteorNum.Four;
                case (5):
                    meteor = MeteorNum.Five;
               
            }
            factory.Mymeteor = meteor;
        }
    }
}
