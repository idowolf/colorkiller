using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MeteorNum
{
    One,
    Two,
    Three,
    Four
}

public class MeteorType : MonoBehaviour
{
    public MeteorNum myMeteor;
    private GameObject selectedMeteor;
    public GameObject[] meteorPrefabs;
    public bool random;
    // Use this for initialization
    void Start()
    {
        ChooseMeteor(myMeteor, random);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChooseMeteor(MeteorNum newMeteor = MeteorNum.One, bool random = true)
    {
        if(!random)
            this.myMeteor = newMeteor;
        else
        {
            this.myMeteor = (MeteorNum)(Random.Range(0, 5));
        }
        switch (myMeteor)
        {
            case MeteorNum.One:
                selectedMeteor = meteorPrefabs[0];
                break;
            case MeteorNum.Two:
                selectedMeteor = meteorPrefabs[1];
                break;
            case MeteorNum.Three:
                selectedMeteor = meteorPrefabs[2];
                break;
            case MeteorNum.Four:
                selectedMeteor = meteorPrefabs[3];
                break;
        }
    }

    public GameObject GetMeteor()
    {
        return selectedMeteor;
    }
}
