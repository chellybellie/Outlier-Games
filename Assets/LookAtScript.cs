using UnityEngine;
using System.Collections;
using UnityEngine.AI;
[RequireComponent(typeof(Animator))]
public class LookAtScript : MonoBehaviour
{
    public Vector3 CurrentPosition;
    public Vector3 LastPosition;
    public float eyeheight=1.8f;
    void Start()
    {
        //if (!head)
        //{
        //    Debug.LogError("No head transform - LookAt disabled");
        //    enabled = false;
        //    return;
        //}
        //animator = GetComponent<Animator>();
        //lookAtTargetPosition = head.position + transform.forward;
        //lookAtPosition = lookAtTargetPosition;
        
    }

    public void Update()
    {
        //Vector3 tmpv= (GetComponent<NavMeshAgent>().steeringTarget);
        //tmpv.y = eyeheight;
        //transform.LookAt(tmpv);
        //Debug.Log(tmpv);

        CurrentPosition = transform.position;
        if (LastPosition == null)
            LastPosition = CurrentPosition - transform.forward;
        Vector3 dir = CurrentPosition - LastPosition;
        transform.LookAt(CurrentPosition + dir);
        LastPosition = CurrentPosition;


    }

    void OnAnimatorIK()
    {
        //lookAtTargetPosition.y = head.position.y;
        //float lookAtTargetWeight = looking ? 1.0f : 0.0f;

        //Vector3 curDir = lookAtPosition - head.position;
        //Vector3 futDir = lookAtTargetPosition - head.position;

        //curDir = Vector3.RotateTowards(curDir, futDir, 6.28f * Time.deltaTime, float.PositiveInfinity);
        //lookAtPosition = head.position + curDir;

        //float blendTime = lookAtTargetWeight > lookAtWeight ? lookAtHeatTime : lookAtCoolTime;
        //lookAtWeight = Mathf.MoveTowards(lookAtWeight, lookAtTargetWeight, Time.deltaTime / blendTime);
        //animator.SetLookAtWeight(lookAtWeight, 0.2f, 0.5f, 0.7f, 0.5f);
        //animator.SetLookAtPosition(lookAtPosition);
    }
}