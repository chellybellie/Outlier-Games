using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class equipScript : MonoBehaviour
{
    enum Weapons { WRENCH, PISTOL, EMPTY, MOP, SYRINGE};
    Weapons held;

    public Image gun;
    public Image wrench;
    public Image mop;
    public Image syringe;

	void Start () {
        held = Weapons.EMPTY;
	}
	
	// Update is called once per frame
	void Update () {
		switch(held)
        {
            case Weapons.EMPTY:
                gun.enabled = false;
                wrench.enabled = false;
                mop.enabled = false;
                syringe.enabled = false;
                break;
            case Weapons.WRENCH:
                gun.enabled = false;
                wrench.enabled = true;
                mop.enabled = false;
                syringe.enabled = false;
                break;
            case Weapons.PISTOL:
                gun.enabled = true;
                wrench.enabled = false;
                mop.enabled = false;
                syringe.enabled = false;
                break;
            case Weapons.MOP:
                gun.enabled = false;
                wrench.enabled = false;
                mop.enabled = true;
                syringe.enabled = false;
                break;
            case Weapons.SYRINGE:
                gun.enabled = false;
                wrench.enabled = false;
                mop.enabled = false;
                syringe.enabled = true;
                break;
            default:
                break;
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            held = Weapons.EMPTY;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            held = Weapons.WRENCH;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            held = Weapons.PISTOL;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            held = Weapons.MOP;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            held = Weapons.SYRINGE;
        }
    }
}
