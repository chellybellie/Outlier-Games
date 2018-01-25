using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPScript : MonoBehaviour {

    public Image hpBar;
    public Image bleedBar;
    public Text hpText;

    public float HP;
    public float bleedHP;
    public float hit;
    public float bleed;
    public float bleedSeverity;

    public string bleedState;
	void Start () {
        bleedSeverity = 1;
        bleed = 0;
        hit = 0;
        HP = 100;
        bleedHP = 100;
        bleedState = "Stable";
	}
	
	// Update is called once per frame
	void Update () {
        hpText.text = ((int)HP).ToString() + " - " + bleedState;
        hpBar.fillAmount = (HP / 100);
        bleedBar.fillAmount = (bleedHP / 100);
        if(hit > 0||bleed > 0)
        {
            TakeHit(hit, bleed, bleedSeverity);
        }
        if(bleedHP < HP)
        {
            Bleed();
        }
        else
        {
            bleedState = "Stable"; 
        }

        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            hit = 20;
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            hit = 10;
            bleed = 10;
            bleedSeverity = 1;
            bleedState = "Bleed";
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            hit = 0;
            bleed = 20;
            bleedSeverity = 3;
            bleedState = "Severe Bleed";
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            hit = 0;
            bleed = 40;
            bleedSeverity = 5;
            bleedState = "Extreme Bleed";
        }
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            hit = 0;
            bleed = 0;
            bleedSeverity = 1;
            HP = 100;
            bleedHP = 100;
            bleedState = "Stable";
        }
    }

    void TakeHit(float h, float b, float s)
    {
        HP -= h;
        bleedHP -= h;
        bleedHP -= b;
        bleedSeverity = s;
        hit = 0;
        bleed = 0;
    }

    void Bleed()
    {
        HP -= (bleedSeverity * Time.deltaTime);
    }
}
