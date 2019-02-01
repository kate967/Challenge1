using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    /*start teleporter to setactive false to restrict player
      from going to lvl 2 early*/
    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {

    }
}
