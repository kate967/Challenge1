using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 2f;
    Vector3 pointA;
    Vector3 pointB;

    void Start ()
    {
        //starting and ending points of back and forth motion
        pointA = new Vector3(94, 1, -4);
        pointB = new Vector3(94, 1, 4);
	}

	void Update ()
    {
        //creates repeated back and forth motion
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(pointA, pointB, time);
	}
}
