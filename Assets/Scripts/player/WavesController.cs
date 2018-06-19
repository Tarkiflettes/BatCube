using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesController : MonoBehaviour
{

    public FrequenceWave frequenceWave;

    public void disable()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Interactive");
        foreach (GameObject obj in objectsWithTag)
        {
            if (obj.GetComponent<Interactive>() != null)
                obj.GetComponent<Interactive>().notify(false, frequenceWave.currentFrequence);
            //obj.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Interactive")
        {
            collision.gameObject.GetComponent<Interactive>().notify(true, frequenceWave.currentFrequence);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Interactive")
        {
            collision.gameObject.GetComponent<Interactive>().notify(false, frequenceWave.currentFrequence);
        }
    }

}
