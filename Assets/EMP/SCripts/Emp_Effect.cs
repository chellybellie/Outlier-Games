using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emp_Effect : MonoBehaviour {

   public  ParticleSystem ps;

    void start()
    {
        //ps=GetComponent<ParticleSystem>();

    }

    public void EMPparticalStart()
    {
        ps.Play();
    }

    public void EMPparticalStop()
    {
        ps.Stop();
        
    }


}
