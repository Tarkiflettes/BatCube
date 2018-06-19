using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrequenceWave : MonoBehaviour
{

    public int maxFrequence;
    public int minFrequence;
    public int currentFrequence;
    public float frequenceBarSize;
    public float barSize;
    public int maxCharge;
    public int currentCharge;
    public string message;
    public PlayerController playerController;

    private GUIStyle currentStyle, colorBar;

    void Start()
    {
        barSize = Screen.height / 10 * 8;
        maxCharge = 5;
        currentCharge = 5;
        maxFrequence = 900;
        minFrequence = 100;
        currentFrequence = 500;
        message = "Charges : " + currentCharge + "/" + maxCharge;

        frequenceBarSize = (Screen.height / 10 * 8) * (currentFrequence / (float)maxFrequence);

        
    }

    void Update()
    {
        if (currentCharge >= maxCharge)
        {
            currentCharge = maxCharge;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            AddJustCurrentFrequence((int)Mathf.Abs(Input.GetAxis("Mouse ScrollWheel") * 500));
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            AddJustCurrentFrequence(-(int)Mathf.Abs(Input.GetAxis("Mouse ScrollWheel") * 500));
        }

    }

    void OnGUI()
    {
        currentStyle = new GUIStyle(GUI.skin.box);

        currentStyle.normal.background = MakeTex(2, 2, new Color(0f, 1f, 0f, 1f));

		colorBar = new GUIStyle(GUI.skin.box);

		colorBar.normal.background = MakeTex(2, 2, new Color(0f, 1f, 1f, 1f));



        if (currentCharge <= 0)
        {
            message = "<color=black>Rechargez!!</color>";
            currentStyle.normal.background = MakeTex(2, 2, new Color(1f, 0f, 0f, 1f));
        }
        else if (currentCharge <= 2)
        {
            message = "<color=black>Charges : " + currentCharge + "/" + maxCharge + "</color>";
            // Couleur rouge
            currentStyle.normal.background = MakeTex(2, 2, new Color(1f, 0.3f, 0f, 1f));
        }
        else if (currentCharge <= 3)
        {
            message = "<color=black>Charges : " + currentCharge + "/" + maxCharge + "</color>";
            // Couleur jaune
            currentStyle.normal.background = MakeTex(2, 2, new Color(1F, 0.92F, 0.016F, 1F));
        }
        else {
            message = "<color=black>Charges : " + currentCharge + "/" + maxCharge + "</color>";
            //Couleur verte
            currentStyle.normal.background = MakeTex(2, 2, new Color(0f, 1f, 0f, 1f));
        }


		if (100 <= currentFrequence && currentFrequence <= 300)
		{
			colorBar.normal.background = MakeTex (2, 2, new Color (1, 1, 1)); // White
		}
		if (301 <= currentFrequence && currentFrequence <= 500)
		{
			colorBar.normal.background = MakeTex (2, 2, new Color(1, 0, 0)); // rouge
		}
		if (501 <= currentFrequence && currentFrequence <= 700)
		{
			colorBar.normal.background = MakeTex (2, 2, new Color(1, 0.92F, 0.016F)); // jaune
		}
		if (701 <= currentFrequence && currentFrequence <= 900)
		{
			colorBar.normal.background = MakeTex (2, 2, new Color(0, 1, 0)); // vert
		}



        GUI.Box(new Rect(Screen.width - 70, Screen.height / 10 * 9 - frequenceBarSize, 50, frequenceBarSize),
			"<color=black>" + currentFrequence + "</color>",colorBar);
		GUI.Box(new Rect(Screen.width - 70, Screen.height / 10, 50, barSize), "");
        GUI.Box(new Rect(5, 170, 150, 30), "" + message, currentStyle);
    }

    public void AddJustCurrentFrequence(int adj)
    {
        currentFrequence += adj;

        if (currentFrequence < minFrequence)
        {
            currentFrequence = minFrequence;
        }

        if (currentFrequence > maxFrequence)
        {
            currentFrequence = maxFrequence;
        }

        if (maxFrequence < 1)
        {
            maxFrequence = 1;
        }

        frequenceBarSize = (Screen.height / 10 * 8) * (currentFrequence / (float)maxFrequence);
    }

    private Texture2D MakeTex(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; ++i)
        {
            pix[i] = col;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }

    public int getCurrentFrequence()
    {
        return currentFrequence;
    }

    public int getCurrentCharge()
    {
        return currentCharge;
    }

    public void setCurrentCharge(int nbrCharges)
    {
        currentCharge = nbrCharges;
    }
}
