using UnityEngine;
using System.Collections;

public class Doors : MonoBehaviour {

    public Animator anim;
    public UnityEngine.AI.NavMeshObstacle navMeshObstacle;
    bool doorOpen;
    bool doorClosed;
    public float doorLevel;

    Animator animator;
    bool Open;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

	void Start()
	{
		Open = false;
		animator = GetComponent<Animator>();

	}

	void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("DoorTry");
            if (col.gameObject.GetComponent<playerController>().keyLevel >= doorLevel)
            {
                Debug.Log("OpenDoorPlease");
                navMeshObstacle.carving = false;
                doorOpen = true;
                doorClosed = false;
                anim.Play("DoorOpen");
            }
        }
        if (col.gameObject.CompareTag("enemy"))
        {
            // gameObject.GetComponent<NavMeshObstacle>().enabled = true;
            doorClosed = false;
            doorOpen = true;
            anim.Play("DoorOpen");
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

