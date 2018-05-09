using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoomPatrol : MonoBehaviour {

    public Transform[] points;
    public int destPoint = 0;
    public NavMeshAgent agent;
    public  Transform Target;
    public bool isChasingPlayer;
    public Animator anim;
    

    void Start()
    {
       
        //float result = Vector3.Dot(new Vector3(1, 1, 1).normalized, new Vector3(1, 2, 1).normalized);
        //agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.autoBraking = false;
        isChasingPlayer = false;
        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;
        
        Target  = points[destPoint];
        destPoint = (destPoint + 1) % points.Length;
        Debug.Log("Going To Next Point");
    }


    void Update()
    {
        Debug.Log(Vector3.Distance(gameObject.transform.position, Target.transform.position));
        
        if (Vector3.Distance(gameObject.transform.position, Target.transform.position) < 1 && !isChasingPlayer)
        {
            GotoNextPoint();
            Debug.Log("remaining Distance");
        }

        if(Target != null)
        {
            agent.SetDestination(Target.transform.position);
            anim.SetBool("Walking", true);
            
        }

        if(Target == null)
        {
            GotoNextPoint();
            anim.Play("walking");
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
            Target = other.gameObject.transform;
            isChasingPlayer = true;
            anim.SetBool("Walking", false);
            anim.SetBool("Attacking", true);
        }
        
     
    }

    private void OnTriggerExit(Collider other)
    {
        //Resume Predetermined Path
        if (other.tag == "Player")
        {
            GotoNextPoint();
            isChasingPlayer = false;
            anim.SetBool("Walking", true);
            anim.SetBool("Attacking", false);
        }
    
    }
}