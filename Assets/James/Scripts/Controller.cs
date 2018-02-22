using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public float moveSpeed = 6;

    Rigidbody rigidbody;
    Vector3 velocity;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        
    }
	
	void Update () {
      
        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * moveSpeed;
	}

    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position - velocity * Time.fixedDeltaTime);    
    }
}
