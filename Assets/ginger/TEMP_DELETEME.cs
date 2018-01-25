using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMP_DELETEME : MonoBehaviour {

    public Transform target;

    Vector2 cameraRotation;

    Vector2 cameraInput
    {
        get
        {
            return new Vector2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X")) * sensitivity;
        }
    }

    public float sensitivity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SetInput();
        SetPosition();
        RotateCamera();
	}

    void SetInput()
    {
        cameraRotation += cameraInput;
    }

    void SetPosition()
    {
        transform.position = target.position;
    }

    void RotateCamera()
    {
        transform.localRotation = Quaternion.Euler(cameraRotation.x, cameraRotation.y, 0);
    }
}
