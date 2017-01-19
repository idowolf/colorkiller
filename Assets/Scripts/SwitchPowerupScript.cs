using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchPowerupScript : SpeedupArcPowerupScript
{
    new void Start()
    {
        base.Start();
        base.multiplier = 0.3f;
    }
}