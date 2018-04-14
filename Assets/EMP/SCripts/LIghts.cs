using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public EMP emp;
   
    public void LightShutdown()
    {
        //float empDistancedChk = Vector3.Distance(emp.EMPTester.transform.position, transform.position);
        GameObject[] LightSource = GameObject.FindGameObjectsWithTag("Light");
        foreach (GameObject tgo in LightSource)
        {

            if (Vector3.Distance(emp.EMPTester.transform.position, tgo.transform.position) < emp.radius)
            {
                Light tmpLight = tgo.GetComponent<Light>();
                MeshRenderer tempMR = tgo.GetComponent<MeshRenderer>();
                FogLight tempFL = tgo.GetComponent<FogLight>();
                MeshRenderer tmpchild = tgo.GetComponentInChildren<MeshRenderer>();
                LightRandomFlicker lft = tgo.GetComponent<LightRandomFlicker>();

                if (tmpLight != null)
                    tmpLight.enabled = false;
                if (tempMR != null)
                    tempMR.enabled = false;
                if (tempFL != null)
                    tempFL.enabled = false;
                if (tmpchild != null)
                    tmpchild.enabled = false;
                if (lft != null)
                    lft.enabled = false;


                AreaLight tmpLight2 = tgo.GetComponent<AreaLight>();
                MeshRenderer tempMR2 = tgo.GetComponent<MeshRenderer>();
                FogLight tempFL2 = tgo.GetComponent<FogLight>();
                MeshRenderer tmpchild2 = tgo.GetComponentInChildren<MeshRenderer>();
                LightRandomFlicker lft2 = tgo.GetComponent<LightRandomFlicker>();
                if (tmpLight2 != null)
                    tmpLight2.enabled = false;
                if (tempMR2 != null)
                    tempMR2.enabled = false;
                if (tempFL2 != null)
                    tempFL2.enabled = false;
                if (tmpchild2 != null)
                    tmpchild2.enabled = false;
                if (lft2 != null)
                    lft2.enabled = false;
                
                TubeLight tmpLight3 = tgo.GetComponent<TubeLight>();
                MeshRenderer tempMR3 = tgo.GetComponent<MeshRenderer>();
                FogLight tempFL3 = tgo.GetComponent<FogLight>();
                MeshRenderer tmpchild3 = tgo.GetComponentInChildren<MeshRenderer>();
                LightRandomFlicker lft3 = tgo.GetComponent<LightRandomFlicker>();
                if (tmpLight3 != null)
                    tmpLight3.enabled = false;
                if (tempMR2 != null)
                    tempMR3.enabled = false;
                if (tempFL3 != null)
                    tempFL3.enabled = false;
                if (tmpchild3 != null)
                    tmpchild3.enabled = false;
                if (lft3 != null)
                    lft3.enabled = false;



            }

        }
    }




    public void LightSwitchOn()
    {
        GameObject[] LightSource = GameObject.FindGameObjectsWithTag("Light");
        foreach (GameObject tgo in LightSource)
        {

            Light tmpLight = tgo.GetComponent<Light>();
            MeshRenderer tempMR = tgo.GetComponent<MeshRenderer>();
            FogLight tempFL = tgo.GetComponent<FogLight>();
            MeshRenderer tmpchild = tgo.GetComponentInChildren<MeshRenderer>();
            LightRandomFlicker lft = tgo.GetComponent<LightRandomFlicker>();

               if (tmpLight != null)
                 tmpLight.enabled = true;
            if (tempMR != null)
                tempMR.enabled = true;
            if (tempFL != null)
                tempFL.enabled = true;
            if (tmpchild != null)
                tmpchild.enabled = true;
            if (lft != null)
                lft.enabled = true;


            AreaLight tmpLight2 = tgo.GetComponent<AreaLight>();
            MeshRenderer tempMR2 = tgo.GetComponent<MeshRenderer>();
            FogLight tempFL2 = tgo.GetComponent<FogLight>();
            MeshRenderer tmpchild2 = tgo.GetComponentInChildren<MeshRenderer>();
            LightRandomFlicker lft2 = tgo.GetComponent<LightRandomFlicker>();

            if (tmpLight2 != null)
               tmpLight2.enabled = true;
            if (tempMR2 != null)
                tempMR2.enabled = true;
            if (tempFL2 != null)
                tempFL2.enabled = true;
            if (tmpchild2 != null)
                tmpchild2.enabled = true;
            if (lft2 != null)
                lft2.enabled = true;

            TubeLight tmpLight3 = tgo.GetComponent<TubeLight>();
            MeshRenderer tempMR3 = tgo.GetComponent<MeshRenderer>();
            FogLight tempFL3 = tgo.GetComponent<FogLight>();
            MeshRenderer tmpchild3 = tgo.GetComponentInChildren<MeshRenderer>();
            LightRandomFlicker lft3 = tgo.GetComponent<LightRandomFlicker>();

            if (tmpLight3 != null)
               tmpLight3.enabled = true;
            if (tempMR2 != null)
                tempMR3.enabled = true;
            if (tempFL3 != null)
                tempFL3.enabled = true;
            if (tmpchild3 != null)
                tmpchild3.enabled = true;
            if (lft3 != null)
                lft3.enabled = true;



        }

    }
}


