using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class headBobScript : MonoBehaviour
{
    
    public Camera cam;
    public bool isMoving;
    private float moveTime;
    public Vector3 resetCam;
    void Start()
    {
        moveTime = 1;
        resetCam = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        



        if (isMoving)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveTime += (Time.deltaTime) / 2.5f;
            }
            moveTime += Time.deltaTime;
            if (moveTime > 1)
            {
                cam.transform.localPosition = (resetCam + new Vector3(0, (Mathf.Cos(moveTime * 15)) / 15, 0));
            }
            else if (moveTime < 1)
            {
                cam.transform.localPosition = resetCam;
            }
            
        }
        
    }
    
}
