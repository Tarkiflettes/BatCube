using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpController : Interactive
{
    
    public bool changeColor = true;
    public WarpController receiver;
    public Material white;
    public Material yellow;
    public Material green;
    public Material red;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ghost")
        {
            if (isGoodFrequency(receiver.minFrequency))
            {
                Vector3 tp = receiver.transform.position;
                tp.x += 2f;
                collision.gameObject.transform.position = tp;
            }
        }
    }

    public override void notify(bool state, int currentFrenquence)
    {
        if (100 <= currentFrenquence && currentFrenquence <= 300)
        {
            minFrequency = 100;
            maxFrequency = 310;
            GetComponent<Renderer>().material = white;
        }
        if (301 <= currentFrenquence && currentFrenquence <= 500)
        {
            minFrequency = 301;
            maxFrequency = 500;
            GetComponent<Renderer>().material = red;
        }
        if (501 <= currentFrenquence && currentFrenquence <= 700)
        {
            minFrequency = 501;
            maxFrequency = 700;
            GetComponent<Renderer>().material = yellow;
        }
        if (701 <= currentFrenquence && currentFrenquence <= 900)
        {
            minFrequency = 701;
            maxFrequency = 900;
            GetComponent<Renderer>().material = green;
        }
    }

}
