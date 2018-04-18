using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testAbilityScript : MonoBehaviour
{

    public int abilitySelect = 0;
    public float selection = 0;
    float zeroPunch = 25;

    public Image aZero;
    public Image aOne;
    public Image aTwo;
    public Image aThree;

    public Image RaZero;
    public Image RaOne;
    public Image RaTwo;
    public Image RaThree;

    public float hideTime;

    void Start()
    {
        abilitySelect = 0;
        selection = 0;
        zeroPunch = 25;
        hideTime = 2;
    }

    // I call this one the THREE S's
    //Ready? Begin!
    void Update()
    {
        Scroll();//Step one, manage inputs
        Select();//Step two, handle that data
        Show();//Step three, display it!
    }

    public void Scroll()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            selection += .3f;
            if (selection >= 4)
            {
                selection = 0;
            }
            hideTime = 2;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            selection -= .3f;
            if (selection < 0)
            {
                selection = 3.9f;
            }
            hideTime = 2;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") == 0)
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
        Vector2 Zero = Vector2.zero;
        Vector2 One = Vector2.zero;
        Vector2 Two = Vector2.zero;
        Vector2 Three = Vector2.zero;

        if (hideTime < 0)
        {
            Zero = new Vector2(.2f, .2f);
            One = new Vector2(.2f, .2f);
            Two = new Vector2(.2f, .2f);
            Three = new Vector2(.2f, .2f);
        }
        else
        {
            Zero = new Vector2(1, 1);
            One = new Vector2(1, 1);
            Two = new Vector2(1, 1);
            Three = new Vector2(1, 1);
        }

        switch (abilitySelect)
        {
            case 0:
                aZero.enabled = true;
                aOne.enabled = false;
                aTwo.enabled = false;
                aThree.enabled = false;

                Zero *= 1.2f;
                break;
            case 1:
                aZero.enabled = true;
                aOne.enabled = true;
                aTwo.enabled = false;
                aThree.enabled = false;

                One *= 1.2f;
                break;
            case 2:
                aZero.enabled = true;
                aOne.enabled = true;
                aTwo.enabled = true;
                aThree.enabled = false;

                Two *= 1.2f;
                break;
            case 3:
                aZero.enabled = true;
                aOne.enabled = true;
                aTwo.enabled = true;
                aThree.enabled = true;


                Three *= 1.2f;
                break;
            default:
                break;
        }

        RaZero.rectTransform.localScale = Zero;
        RaOne.rectTransform.localScale = One;
        RaTwo.rectTransform.localScale = Two;
        RaThree.rectTransform.localScale = Three;
    }
}
