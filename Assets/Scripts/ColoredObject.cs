using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectColor
{
    White,
    Yellow,
    Pink,
    Purple,
    Turkiz,
}

public class ColoredObject : MonoBehaviour {
    private Color drawColor;
    public ObjectColor color;
    SpriteRenderer ren;
    // Use this for initialization
    void Start () {
        SetColor(color);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SetColor(ObjectColor color = ObjectColor.White)
    {
        this.color = color;
        switch (color)
        {
            case ObjectColor.White:
                drawColor = new Color(1f, 1f, 1f); // white
                break;
            case ObjectColor.Pink:
                drawColor = new Color(1f, 0f, 0.502f); // pink
                break;
            case ObjectColor.Purple:
                drawColor = new Color(0.549f, 0.075f, 0.984f); // purple
                break;
            case ObjectColor.Turkiz:
                drawColor = new Color(0.208f, 0.886f, 0.953f, 1.000f); // turkiz
                break;
            case ObjectColor.Yellow:
                drawColor = new Color(0.965f, 0.875f, 0.055f, 1.000f); // yellow
                break;
        }
        ren = gameObject.GetComponent<SpriteRenderer>();
        ren.color = drawColor;
    }
}
