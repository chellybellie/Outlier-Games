using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMP : MonoBehaviour
{
    public powerScript ChargeBar_UI;
    public GameObject EMPTester;
    public float power = 1f;
    public float radius = 10.0f;
    public float upforce = .5f;
    public float FreezeTimer = 5f;
    private bool Light = true;
    //bool pressed = false;
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && ChargeBar_UI.uses >= 1)
        {
            EMPDetonate();
        }
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
                float powerModifier = 1 - (distance / radius);
                // equation for explosion physics
                rb.AddExplosionForce(power * powerModifier, ExplosionPosition, radius, upforce * powerModifier, ForceMode.Impulse);
                StartCoroutine(FreezeObjects(rb));
            }
        }
    }
    ////// Example of Coroutines//////
    // https://docs.unity3d.com/Manual/Coroutines.html //
    // https://unity3d.com/learn/tutorials/topics/scripting/coroutines //
    // https://stackoverflow.com/questions/12932306/how-does-startcoroutine-yield-return-pattern-really-work-in-unity //

    IEnumerator FreezeObjects(Rigidbody rb)
    {
        float WaitTime = 1f;
        // DEbug console screen///////////////////////////////
        while (WaitTime > 0)
        {
            WaitTime -= 1;

            Debug.Log(WaitTime);

            yield return new WaitForSeconds(1);
        }
        float originalAngularDrag = rb.angularDrag;
        float originalDrag = rb.drag;
        //rb.angularDrag = 4;
        //rb.drag = 4;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        float time = FreezeTimer;
        // DEbug console screen///////////////////////////////
        while (time > 0)
        {
            time -= 1;

            Debug.Log(time);

            yield return new WaitForSeconds(1);
        }
        //////////////////////////////////////////////////////
        rb.constraints = RigidbodyConstraints.None;
        rb.angularDrag = originalAngularDrag;
        rb.drag = originalDrag;
    }

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






