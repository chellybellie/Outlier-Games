using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;
    float sensitivity = 3;

    Camera cam;

	void Start ()
    {
        offset = transform.position - player.transform.position;
	}
	
	
	void LateUpdate ()
    {
        if (Time.timeScale == 1)
        {
            transform.position = player.transform.position + offset;
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * sensitivity, 0));
        }
	}
}
