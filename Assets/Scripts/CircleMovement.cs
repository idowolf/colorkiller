using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CircleDirection
{
    CounterClockwise = 1,
    Clockwise = -1
}
public class CircleMovement : MonoBehaviour
{
    private float angle, x0, y0, calcSpeed;
    public float timeToCompleteCircle = 20;
    public float radius;
    CircleDirection circleDirection;
    // Use this for initialization
    void Start()
    {
        angle = 0f;
        x0 = transform.position.x;
        y0 = transform.position.y;
        calcSpeed = (2 * Mathf.PI) / timeToCompleteCircle;
        circleDirection = CircleDirection.CounterClockwise;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = x0 + Mathf.Cos(angle) * radius;
        pos.y = y0 + Mathf.Sin(angle) * radius;
        transform.position = pos;
        angle += calcSpeed * Time.deltaTime * (int)circleDirection; //if you want to switch direction, use -= instead of +=
    }
}