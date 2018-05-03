using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testAbilityScript : MonoBehaviour {

    public int abilitySelect = 0;
    public float selection = 0;
    float zeroPunch = 25;

    //public Image aZero;
    //public Image aOne;
    //public Image aTwo;
    //public Image aThree;

    public Image RaZero;
    public Image RaOne;
    public Image RaTwo;
    public Image RaThree;

    public Vector3 zeroReset;
    public Vector3 oneReset;
    public Vector3 twoReset;
    public Vector3 threeReset;

    public Vector3 zeroSelect;
    public Vector3 oneSelect;
    public Vector3 twoSelect;
    public Vector3 threeSelect;
    public float hideTime;

    public Vector2 shrinkTarget;

    void Start () {
        abilitySelect = 0;
        selection = 0;
        zeroPunch = 25;
        hideTime = 2;

        zeroReset = RaZero.rectTransform.localPosition;
        oneReset = RaOne.rectTransform.localPosition;
        twoReset = RaTwo.rectTransform.localPosition;
        threeReset = RaThree.rectTransform.localPosition;

        zeroSelect = zeroReset;
        oneSelect = oneReset + new Vector3(-.08f, 0, 0);
        twoSelect = twoReset + new Vector3(-.08f, -.08f, 0);
        threeSelect = threeReset + new Vector3(0, -.08f, 0);

        shrinkTarget = new Vector2(.2f, .2f);
}
	
	// I call this one the THREE S's
    //Ready? Begin!
	void Update () {
        Scroll();//Step one, manage inputs
        Select();//Step two, handle that data
        Show();//Step three, display it!
	}

    public void Scroll()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            selection += .3f;
            if(selection >= 4)
            {
                selection = 0;
            }
            hideTime = 2;
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            selection -= .3f;
            if (selection < 0)
            {
                selection = 3.9f;
            }
            hideTime = 2;
        }
        else if(Input.GetAxis("Mouse ScrollWheel") == 0)
        {
            hideTime -= Time.deltaTime;
        }

    }

    public void Select()
    {
        if (selection >= 0 && selection < 1)
        {
            abilitySelect = 0;
        }
        if (selection >= 1 && selection < 2)
        {
            abilitySelect = 1;
        }
        if (selection >= 2 && selection < 3)
        {
            abilitySelect = 2;
        }
        if (selection >= 3 && selection < 4)
        {
            abilitySelect = 3;
        }
    }

    public void Show()
    {
        RectTransform Zero = RaZero.rectTransform;
        RectTransform One = RaOne.rectTransform;
        RectTransform Two = RaTwo.rectTransform;
        RectTransform Three = RaThree.rectTransform;
       
        if(hideTime < 0)
        {
            if(Zero.localScale.x > .4f)
            {
                Zero.localScale = new Vector3(Zero.localScale.x - (Time.deltaTime * .4f), Zero.localScale.y - (Time.deltaTime * .4f), 1);
                One.localScale = new Vector3(One.localScale.x - (Time.deltaTime * .4f), One.localScale.y - (Time.deltaTime * .4f), 1);
                Two.localScale = new Vector3(Two.localScale.x - (Time.deltaTime * .4f), Two.localScale.y - (Time.deltaTime * .4f), 1);
                Three.localScale = new Vector3(Three.localScale.x - (Time.deltaTime * .4f), Three.localScale.y - (Time.deltaTime * .4f), 1);
            }
           
        }
        else
        {
            if (Zero.localScale.x < 1 && One.localScale.x < 1 && Two.localScale.x < 1 && Three.localScale.x < 1)
            {
                Zero.localScale = new Vector2(Zero.localScale.x + (Time.deltaTime * .6f), Zero.localScale.y + (Time.deltaTime * .6f));
                One.localScale = new Vector2(One.localScale.x + (Time.deltaTime * .6f), One.localScale.y + (Time.deltaTime * .6f));
                Two.localScale = new Vector2(Two.localScale.x + (Time.deltaTime * .6f), Two.localScale.y + (Time.deltaTime * .6f));
                Three.localScale = new Vector2(Three.localScale.x + (Time.deltaTime * .6f), Three.localScale.y + (Time.deltaTime * .6f));
            }
            else
            {
                Zero.localScale = new Vector3(1, 1, 1);
                One.localScale = new Vector3(1, 1, 1);
                Two.localScale = new Vector3(1, 1, 1);
                Three.localScale = new Vector3(1, 1, 1);
            }
   
        }

        switch (abilitySelect)
        {
            case 0:
                //aZero.enabled = true;
                //aOne.enabled = false;
                //aTwo.enabled = false;
                //aThree.enabled = false;
                if (hideTime < 0.2f && hideTime > 0)
                {
                    Zero.localScale = new Vector3(1, 1, 1);
                }
                else if(hideTime > .2f)
                {
                    Zero.localScale *= 1.2f;
                }


                  
                Zero.localPosition = zeroSelect;
                One.localPosition = oneReset;
                Two.localPosition = twoReset;
                Three.localPosition = threeReset;
                break;
            case 1:
                //aZero.enabled = true;
                //aOne.enabled = true;
                //aTwo.enabled = false;
                //aThree.enabled = false;

                if (hideTime < 0.2f && hideTime > 0)
                {
                    One.localScale = new Vector3(1, 1, 1);
                }
                else if (hideTime > .2f)
                {
                    One.localScale *= 1.2f;
                }
                
                One.localPosition = oneSelect;
                Zero.localPosition = zeroReset;
                Two.localPosition = twoReset;
                Three.localPosition = threeReset;
                break;
            case 2:
                //aZero.enabled = true;
                //aOne.enabled = true;
                //aTwo.enabled = true;
                //aThree.enabled = false;
                if (hideTime < 0.2f && hideTime > 0)
                {
                    Two.localScale = new Vector3(1, 1, 1);
                }
                else if (hideTime > .2f)
                {
                    Two.localScale *= 1.2f;
                }
             
                Two.localPosition = twoSelect;
                Zero.localPosition = zeroReset;
                One.localPosition = oneReset;
                Three.localPosition = threeReset;
                break;
            case 3:
                //aZero.enabled = true;
                //aOne.enabled = true;
                //aTwo.enabled = true;
                //aThree.enabled = true;
                if (hideTime < 0.2f && hideTime > 0)
                {
                    Three.localScale = new Vector3(1, 1, 1);
                }
                else if (hideTime > .2f)
                {
                    Three.localScale *= 1.2f;
                }

                
                Three.localPosition = threeSelect;
                Zero.localPosition = zeroReset;
                One.localPosition = oneReset;
                Two.localPosition = twoReset;
                break;
            default:
                break;
        }

        RaZero.rectTransform.localScale = Zero.localScale;
        RaZero.rectTransform.localPosition = Zero.localPosition;

        RaOne.rectTransform.localScale = One.localScale;
        RaOne.rectTransform.localPosition = One.localPosition;

        RaTwo.rectTransform.localScale = Two.localScale;
        RaTwo.rectTransform.localPosition = Two.localPosition;

        RaThree.rectTransform.localScale = Three.localScale;
        RaThree.rectTransform.localPosition = Three.localPosition;

        //Zero.localPosition = zeroReset;
        //One.localPosition = oneReset;
        //Two.localPosition = twoReset;
        //Three.localPosition = threeReset;
    }
}
