using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : Interactive
{

    public Rigidbody brokenWindow;

    private Rigidbody rb;
    private BoxCollider bc;
    private MeshRenderer mr;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
        mr = GetComponent<MeshRenderer>();
    }

    public override void notify(bool state, int currentFrenquence)
    {
        //Rigidbody brokenWindowInstance = Instantiate(brokenWindow, brokenWindow.position, brokenWindow.rotation) as Rigidbody;
        //brokenWindow.GetComponent<BoxCollider>().enabled = true;
        //brokenWindow.GetComponent<MeshRenderer>().enabled = true;
        if (state && isGoodFrequency())
        {
            foreach (Transform child in brokenWindow.transform)
            {
                child.gameObject.GetComponent<BoxCollider>().enabled = true;
                child.gameObject.GetComponent<MeshRenderer>().enabled = true;
                child.gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
            //rb. = false;
            bc.enabled = false;
            mr.enabled = false;
        }
    }

}
