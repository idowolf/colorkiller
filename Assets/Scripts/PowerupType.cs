using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerupNum
{
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven
    
}

public class PowerupType : MonoBehaviour
{
    public PowerupNum myPowerup;
    private GameObject selectedPowerup;
    public GameObject[] powerupPrefabs;
    public bool random;
    // Use this for initialization
    void Start()
    {
        ChoosePowerup(myPowerup, random);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChoosePowerup(PowerupNum newPowerup = PowerupNum.One, bool random = true)
    {
        if(!random)
            this.myPowerup = newPowerup;
        else
        {
            this.myPowerup = (PowerupNum)(Random.Range(0, 5));
        }
        switch (myPowerup)
        {
            case PowerupNum.One:
                selectedPowerup = powerupPrefabs[0];
                break;
            case PowerupNum.Two:
                selectedPowerup = powerupPrefabs[1];
                break;
            case PowerupNum.Three:
                selectedPowerup = powerupPrefabs[2];
                break;
            case PowerupNum.Four:
                selectedPowerup = powerupPrefabs[3];
                break;
            case PowerupNum.Five:
                selectedPowerup = powerupPrefabs[4];
                break;
            case PowerupNum.Six:
                selectedPowerup = powerupPrefabs[5];
                break;
            case PowerupNum.Seven:
                selectedPowerup = powerupPrefabs[6];
                break;
        }
    }

    public GameObject GetPowerup()
    {
        return selectedPowerup;
    }
}
