using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerScript : MonoBehaviour
{
  //  public Text amount;
    public GameObject bar;
    public GameObject pipOne, pipTwo, pipThree;
   
    //AudioSource zap;
    //public AudioClip zappity;
 //   public float noteTime;
    public float power;
    public float charge;
    public int uses;
    public GloveIndicators gloveInd;
    EMP empScript;
    void Start()
    {
        power = 0;
        charge = 10;
 

        empScript = gameObject.GetComponent<EMP>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (power < 100)
        {
            power += (charge * Time.deltaTime);

            gloveInd.SetPowerTo((int)power, new Color32(71, 244, 254, 255),new Color32(39,20,97,255));
                
            if (power >= 100)
            {
                if (uses < 3)
                {
                    power = 0;
                    uses++;
                }
                else if (uses >= 3)
                {
                    power = 100;
                }
            }

        }
        if (power == 100 && uses < 3)
        {
            uses++;
            power = 0;
            

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (uses > 0 || power > 25)
            {
                //zap.PlayOneShot(zappity, 1f);

                empScript.RunThrough();
            }
            else
            {
               

            }
        }

      //  amount.text = ((int)power).ToString();

        switch (uses)
        {
            case 0:
               //pipOne.enabled = false;
                gloveInd.SwitchPipOff(0);
               // pipTwo.enabled = false;
                gloveInd.SwitchPipOff(1);
               // pipThree.enabled = false;
                gloveInd.SwitchPipOff(2);
                break;
            case 1:
              //  pipOne.enabled = true;
                gloveInd.SwitchPipOn(0);
               // pipTwo.enabled = false;
                gloveInd.SwitchPipOff(1);
               // pipThree.enabled = false;
                gloveInd.SwitchPipOff(2);
                break;
            case 2:
               // pipOne.enabled = true;
                gloveInd.SwitchPipOn(0);
               // pipTwo.enabled = true;
                gloveInd.SwitchPipOn(1);
               // pipThree.enabled = false;
                gloveInd.SwitchPipOff(2);
                break;
            case 3:
               // pipOne.enabled = true;
                gloveInd.SwitchPipOn(0);
               // pipTwo.enabled = true;
                gloveInd.SwitchPipOn(1);
               // pipThree.enabled = true;
                gloveInd.SwitchPipOn(2);
                break;
            default:
                break;
        }
    }
}
