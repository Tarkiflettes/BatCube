using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : Interactive
{
    public DoorController doorController;

    private Rigidbody button;

    // Use this for initialization
    void Start()
    {
        button = GetComponent<Rigidbody>();
    }

    public void Action()
    {
        AudioSource audio = GetComponent<AudioSource>();
        doorController.GetComponent<Rigidbody>();
        doorController.open();
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void notify(bool state, int currentFrenquence)
    {
        if (isGoodFrequency() && state)
            GetComponent<MeshRenderer>().enabled = state;
        else
            GetComponent<MeshRenderer>().enabled = false;
        //GetComponent<Collider>().enabled = state;
    }
}
