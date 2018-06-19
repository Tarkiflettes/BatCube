using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriseController : MonoBehaviour
{

    private Rigidbody prise;
    public FrequenceWave frequenceWave;

    // Use this for initialization
    void Start () {

        prise = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Action()
    {
        print("Coucou");
        frequenceWave.setCurrentCharge(5);
    }
}
