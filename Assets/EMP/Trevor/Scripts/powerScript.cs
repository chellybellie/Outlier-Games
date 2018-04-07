using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerScript : MonoBehaviour
{
    public Text amount;
    public Image bar;
    public Image pipOne, pipTwo, pipThree;
    public Text note;
    //AudioSource zap;
    //public AudioClip zappity;
    public float noteTime;
    public float power;
    public float charge;
    public int uses;
    void Start()
    {
        power = 0;
        charge = 10;
        pipOne.enabled = false;
        pipTwo.enabled = false;
        pipThree.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = (power / 100);
        if (power < 100)
        {
            power += (charge * Time.deltaTime);
            if (power >= 100)
            {
                if(uses < 3)
                {
                    power = 0;
                    uses++;
                }
                else if(uses >= 3)
                {
                    power = 100;
                }
            }
            
        }
        if(power == 100 && uses <3)
        {
            uses++;
            power = 0;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (uses > 0)
            {
                //zap.PlayOneShot(zappity, 1f);
                note.text = "! SURGE !";
                noteTime = 0;
                uses--;
            }
            else
            {
                note.text = "! No Charges !";
                noteTime = 0;
            }
        }

        if (noteTime > 3)
        {
            note.text = "";
        }
        else
        {
            noteTime += Time.deltaTime;
        }

        amount.text = ((int)power).ToString();

        switch(uses)
        {
            case 0:
                pipOne.enabled = false;
                pipTwo.enabled = false;
                pipThree.enabled = false;
                break;
            case 1:
                pipOne.enabled = true;
                pipTwo.enabled = false;
                pipThree.enabled = false;
                break;
            case 2:
                pipOne.enabled = true;
                pipTwo.enabled = true;
                pipThree.enabled = false;
                break;
            case 3:
                pipOne.enabled = true;
                pipTwo.enabled = true;
                pipThree.enabled = true;
                break;
            default:
                break;
        }
    }
}
