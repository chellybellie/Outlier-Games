using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveIndicators : MonoBehaviour {
    public Color powerInitialColor;
    public Color healthInitialColor;

    public Material powerMaterial;
    public Material healthBar;

    
    public int fPower = 0;
    public Texture2D powerTexture;
    public Texture2D HealthTexture;

    //public Material pipsOnMaterial;
    //public Material pipsOffMaterial;
    //public Texture2D pipsOnTexture;
    //public Texture2D pipsOffTexture;

    public Material[] pips;
    public Texture2D PipOn;
    public Texture2D PipOff;

    // Use this for initialization
    void Start () {
        powerTexture = new Texture2D(100, 10);
        Color[] pColors = new Color[100 * 10];
        for (int i = 0; i < pColors.Length; i++)
            pColors[i] = powerInitialColor;


        powerTexture.SetPixels(0, 0, 100, 10, pColors);
        powerTexture.Apply();
        powerMaterial.SetTexture("_MainTex", powerTexture);

        HealthTexture = new Texture2D(100, 10);
        Color[] hColors = new Color[100 * 10];
        for (int i = 0; i < hColors.Length; i++)
            hColors[i] = healthInitialColor;


        HealthTexture.SetPixels(0, 0, 100, 10, hColors);
        HealthTexture.Apply();
        healthBar.SetTexture("_MainTex", HealthTexture);

    }
	
	void Update ()
    {
   
    }

    public void SetPowerTo(int f,Color colorOn, Color colorOff)
    {
        Color[] colorOnArray = new Color[10];
        Color[] colorOffArray = new Color[10];
        for (int i = 0; i < 10; i++)
        {
            colorOnArray[i] = colorOn;
            colorOffArray[i] = colorOff;
        }
        
        f = 99 - f;
        
        for (int x = 99; x >f; x--)
            powerTexture.SetPixels(x, 0, 1, 10, colorOnArray);

        for (int x = f; x > 1; x--)
        {
            powerTexture.SetPixels(x, 0, 1, 10, colorOffArray);
            Debug.Log(x);
        }

        powerTexture.Apply();
      
    }



    public void SetHealthTo(int f, Color colorOn, Color colorOff)
    {
        Color[] colorOnArray = new Color[10];
        Color[] colorOffArray = new Color[10];
        for (int i = 0; i < 10; i++)
        {
            colorOnArray[i] = colorOn;
            colorOffArray[i] = colorOff;
        }

        f = 99 - f;

        for (int x = 99; x > f; x--)
            HealthTexture.SetPixels(x, 0, 1, 10, colorOnArray);

        for (int x = f; x > 1; x--)
        {
            HealthTexture.SetPixels(x, 0, 1, 10, colorOffArray);
            Debug.Log(x);
        }

        HealthTexture.Apply();

    }

    public void SwitchPipOn(int pipNo)
    {
        pips[pipNo].SetTexture("_MainTex",PipOn);
        //pipsOnMaterial.SetTexture("_MainTex", pipsOnTexture);
    }
    public void SwitchPipOff(int pipNo)
    {
        pips[pipNo].SetTexture("_MainTex",PipOff);
        //pipsOffMaterial.SetTexture("_MainTex", pipsOffTexture);
    }



}
