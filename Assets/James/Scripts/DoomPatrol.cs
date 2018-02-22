using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoomPatrol : MonoBehaviour {

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public  Transform Target;
    public bool isChasingPlayer = false;
   

    void Start()
    {
       
        float result = Vector3.Dot(new Vector3(1, 1, 1).normalized, new Vector3(1, 2, 1).normalized);
        agent = GetComponent<NavMeshAgent>();
       
        agent.autoBraking = false;
        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;
        
        Target  = points[destPoint];
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f && !isChasingPlayer)
            GotoNextPoint();

        if(Target != null)
        {
            agent.SetDestination(Target.transform.position);
        }

        if(Target == null)
        {
            GotoNextPoint();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            Target = other.gameObject.transform;
            isChasingPlayer = true;
        }
        Debug.Log("Target Locked");
     
    }

    private void OnTriggerExit(Collider other)
    {
        //Resume Predetermined Path
        if (other.tag == "Player")
        {
            GotoNextPoint();
            isChasingPlayer = false;
        }
    Debug.Log("TargetLost");
    }
}