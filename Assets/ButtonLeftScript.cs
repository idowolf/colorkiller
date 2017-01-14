using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class ButtonLeftScript : MonoBehaviour
{
    public void onPointerDownRaceButton()
    {
        Rotate.cmd = InputCmd.RotateLeft;
    }
    public void onPointerUpRaceButton()
    {
        Rotate.cmd = InputCmd.DoNone;
    }
}

