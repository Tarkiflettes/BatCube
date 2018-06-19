using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isOpen = false;

    private Rigidbody door;

    void Start()
    {

        door = GetComponent<Rigidbody>();

        if (isOpen)
        {
            door.GetComponent<MeshRenderer>().enabled = false;
            door.GetComponent<BoxCollider>().enabled = false;
        }
    }

    void Update()
    {

    }

    public void open()
    {

        if (isOpen)
        {
            door.GetComponent<MeshRenderer>().enabled = true;
            door.GetComponent<BoxCollider>().enabled = true;
            isOpen = false;
        }
        else
        {
            door.GetComponent<MeshRenderer>().enabled = false;
            door.GetComponent<BoxCollider>().enabled = false;
            isOpen = true;
        }

    }

}
