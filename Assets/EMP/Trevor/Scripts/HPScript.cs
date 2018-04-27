using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPScript : MonoBehaviour {

    public Image hpBar;
    public Image bleedBar;
    public Text hpText;
   public  GloveIndicators gloveInd;
    public playerController player;
    public float bleedHP;
    public float hit;
    public float bleedSeverity;

    public string bleedState;
	void Start () {
        bleedSeverity = 0;
        bleedHP = 100;
        hit = 0;
        player.health = 100;
        player.bleed = 100;
        bleedState = "OK";
	}
	
	// Update is called once per frame
	void Update () {
        hpText.text = bleedState + " - " + ((int)player.health).ToString();
        hpBar.fillAmount = (player.health / 100);
        bleedBar.fillAmount = (bleedHP / 100);
        if(hit > 0 || player.bleed > 0)
        {
            TakeHit(hit, player.bleed, bleedSeverity);
        }
        if(bleedHP < player.health)
        {
            //Bleed();
        }
        else
        {
            bleedState = "OK"; 
        }

        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            hit = 20;
          
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            hit = 10;
           // player.bleed = 10;
            bleedSeverity = 1;
            bleedState = "Bleed 1";
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            hit = 0;
            //player.bleed = 20;
            bleedSeverity = 3;
            bleedState = "Bleed 2";
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            hit = 0;
           // player.bleed = 40;
            bleedSeverity = 5;
            bleedState = "Bleed 3";
        }
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            hit = 0;
            //player.bleed = 0;
            bleedSeverity = 1;
            player.health = 100;
            bleedHP = 100;
            bleedState = "OK";
        }
    }

    public void TakeHit(float h, float b, float s)
    {
        player.health -= h;
        bleedHP -= h;
        bleedHP -= b;
        bleedSeverity = s;
        hit = 0;
        player.bleed = 0;
    }

    void Bleed()
    {
        player.health -= (bleedSeverity * Time.deltaTime);
        gloveInd.SetHealthTo((int)player.health, new Color32(255, 0, 0,255), new Color32(120, 0, 0, 255));
    }
}
