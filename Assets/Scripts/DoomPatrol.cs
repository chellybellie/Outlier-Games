using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoomPatrol : MonoBehaviour {

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;

        void Start()
    {
        // Dot product gives a number from -1 to 1 describing how similar directions are.
        // If your direction to the player is in the proper range, you can raycast to check line of sight.
        // If there's sight, then follow or whatever
        float result = Vector3.Dot(new Vector3(1, 1, 1).normalized, new Vector3(1, 2, 1).normalized);
        agent = GetComponent<NavMeshAgent>();
       
        agent.autoBraking = false;
        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;
        
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}
