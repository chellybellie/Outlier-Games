using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMP : MonoBehaviour {

    public GameObject EMPTester;
    public float power = 1f;
    public float radius = 10.0f;
    public float upforce = .5f;
     


    bool pressed = false;

    // Use this for initialization 
    void Start()
    {

    }
     
    // Update is called once per frame
    void Update()
    {

        if (!pressed && Input.GetButton("Jump"))
        {
            EMPDetonate();
            pressed = true;
        }
        
    }

    void EMPDetonate()
    {       // gets emps position
        Vector3 ExplosionPosition = EMPTester.transform.position;

        Collider[] colliders = Physics.OverlapSphere(ExplosionPosition, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb != null)
            {
                    // makes physics weaker father away from center radius vertex.
                float distance = Vector3.Distance(rb.transform.position, EMPTester.transform.position);
                float powerModifier = 1 - (distance / radius);
                    // equation for explosion physics
                rb.AddExplosionForce(power * powerModifier, ExplosionPosition, radius, upforce * powerModifier, ForceMode.Impulse);
            }
          
        }

    }
}