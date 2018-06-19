using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : Interactive
{

    public override void notify(bool state, int frequence)
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("koukou");
        }
    }

}
