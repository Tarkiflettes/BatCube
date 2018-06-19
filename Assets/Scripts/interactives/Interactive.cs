using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactive : MonoBehaviour {

    public int minFrequency;
    public int maxFrequency;
    public FrequenceWave frequenceWave;

    protected bool isGoodFrequency()
    {
        return isGoodFrequency(frequenceWave.getCurrentFrequence());
    }

    protected bool isGoodFrequency(int frequence)
    {
        if (minFrequency <= frequence && frequence <= maxFrequency)
        {
            return true;
        }
        return false;
    }

    public abstract void notify(bool state, int currentFrenquencee);

    public static explicit operator Interactive(GameObject v)
    {
        throw new NotImplementedException();
    }
}
