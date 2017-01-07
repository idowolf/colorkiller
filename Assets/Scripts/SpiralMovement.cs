using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralMovement : MonoBehaviour {
    private float angle, x0, y0, calcSpeed;
    public float timeToCompleteCircle = 20;
    public float radius,speedFactor;
    CircleDirection circleDirection;
    // Use this for initialization
    void Start () {
        angle = 0f;
        x0 = transform.position.x;
        y0 = transform.position.y;
        calcSpeed = (2 * Mathf.PI) / timeToCompleteCircle;
        circleDirection = CircleDirection.CounterClockwise;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (radius < 0)
            return;
        Vector3 pos = transform.position;
        radius -= speedFactor * Time.deltaTime;
        pos.x = x0 + Mathf.Cos(angle) * radius;
        pos.y = y0 + Mathf.Sin(angle) * radius;
        transform.position = pos;
        angle += calcSpeed * Time.deltaTime * (int)circleDirection; //if you want to switch direction, use -= instead of +=
    }
}
