using UnityEngine;
using System.Collections;

public class Doors : MonoBehaviour {

	Animator animator;
    bool Open;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

	void Start()
	{
		Open = false;
		animator = GetComponent<Animator>();
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player" || col.gameObject.tag == "enemy")
		{
			Open = true;
			DoorControl (true);
            //Debug.Log("Open");
        }
	}

	void OnTriggerExit(Collider col)
	{
		if(col.gameObject.tag == "Player" || col.gameObject.tag == "enemy")
		{
            Open = false;
			DoorControl (false);
            //Debug.Log("Close");
		}
	}

	void DoorControl(bool open)
	{
		animator.SetBool("Open", open);
	}

}

