using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EMP : MonoBehaviour
{
    public testAbilityScript tas;
    public powerScript ChargeBar_UI;
    public GameObject EMPTester;
    public float power = 1f;          
    public float radius = 10.0f;
    public float upforce = .5f;
    public float FreezeTimer;
    private bool Light = true;
    private float Selector;
    public float Ability;

    void Start()
    {
        Selector = 1;
    }
    // Update is called once per frame
    void Update()
    {
        //EMPController();
    }
    public void EMPDetonate()
    {
        powerScript EMP_UI = GetComponent<powerScript>();
        // gets emps position
        Vector3 ExplosionPosition = EMPTester.transform.position;
        Collider[] colliders = Physics.OverlapSphere(ExplosionPosition, radius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // makes physics weaker father away from center radius vertex.
                float distance = Vector3.Distance(rb.transform.position, EMPTester.transform.position);
                float powerModifier = 10 - (distance / radius);
                // equation for explosion physics
                rb.AddExplosionForce(power * powerModifier, ExplosionPosition, radius, upforce * powerModifier, ForceMode.Impulse);
               StartCoroutine(FreezeObjects(rb));
            }
        }
    }
    IEnumerator FreezeObjects(Rigidbody rb)
    {
        float WaitTime = 1f;
        // DEbug console screen///////////////////////////////
         yield return new WaitForSeconds(WaitTime);
        
        float originalAngularDrag = rb.angularDrag;
        float originalDrag = rb.drag;
        //rb.angularDrag = 4;
        //rb.drag = 4;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        float time = FreezeTimer;
        // DEbug console screen///////////////////////////////
        while (time > 0)
        {

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
            foreach (GameObject enemy in enemies)
            {
                NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
                if (!agent)
                    continue;
                agent.isStopped = true;
            }

                time -= 1;

            Debug.Log(time);

            yield return new WaitForSeconds(1);
        }
        GameObject[] enemiestwo = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemytwo in enemiestwo)
        {
            NavMeshAgent agent = enemytwo.GetComponent<NavMeshAgent>();
            if (!agent)
                continue;
            agent.isStopped = false;
        }
        //////////////////////////////////////////////////////
        rb.constraints = RigidbodyConstraints.None;
        rb.angularDrag = originalAngularDrag;
        rb.drag = originalDrag;
        
    }

     void EMPController()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // foward
        {
            Selector += .1f;
            if(Selector >= 3)
            {
                Selector = 0;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            Selector -= .1f;
            if (Selector < 0)
            {
                Selector = 2.9f;
            }
        }
    }

       public void RunThrough()
    {
        if (tas.abilitySelect == 0 && ChargeBar_UI.power < 99 && ChargeBar_UI.power > 25) 
        {
            FreezeTimer = 1;
            EMPDetonate();
            // LightShutdown();
            ChargeBar_UI.power -= 25;
        }

        if (tas.abilitySelect == 1 && ChargeBar_UI.uses >= 1)
        {
            FreezeTimer = 5;
            EMPDetonate();
            // LightShutdown();
            ChargeBar_UI.uses -= 1;
        }
        if (tas.abilitySelect == 2 && ChargeBar_UI.uses >= 2 )
        {
            FreezeTimer = 10;
            EMPDetonate();
            // LightShutdown();
            ChargeBar_UI.uses -= 2;
        }
        if (tas.abilitySelect == 3 && ChargeBar_UI.uses == 3)
        {
            FreezeTimer = 15;
            EMPDetonate();
            // LightShutdown();
            ChargeBar_UI.uses -= 3;
        }

    }

    //void AbilitySelect()
    //{
    //    if( Selector >=0 && Selector <= .99f )
    //    {
    //        Ability = 0;
    //    }

    //    if (Selector >= 1 && Selector <= 1.99f)
    //    {
    //        Ability = 1;
    //    }
    //    if (Selector >= 2 && Selector <= 2.99f)
    //    {
    //        Ability = 2;
    //    }

    //}



    //void LightShutdown()
    //{

    //    Collider[] LightsInRange = Physics.OverlapSphere(transform.position, radius);
    //    foreach (Collider col in LightsInRange)
    //    {
    //        if (col.tag == "Light")
    //        {


    //        }

    //    }
    //}
}
