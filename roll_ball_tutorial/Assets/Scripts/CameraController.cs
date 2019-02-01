using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

	void Start () {

        offset = transform.position - player.transform.position;

	}
    private void Update()
    {
        /*moved quit application because after
          player dies, you can no longer use
          the escape key to quit out*/
        if (Input.GetKey("escape"))
            Application.Quit();

    }

    void LateUpdate () {
        transform.position = player.transform.position + offset;
	}
}
