using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    /*created second wall movement file to
      account for different starting and
      ending postions*/

    public float speed = 2f;
    Vector3 pointA;
    Vector3 pointB;
    void Start()
    {
        pointA = new Vector3(106, 1, 4);
        pointB = new Vector3(106, 1, -4);
    }

    void Update()
    {
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(pointA, pointB, time);
    }
}
