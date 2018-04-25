using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public EMP emp;
<<<<<<< HEAD

=======
   
>>>>>>> 827137cdd6958d129e58adb87fc0d8b1e7326ede

    public void LightShutdown()
    {
        //float empDistancedChk = Vector3.Distance(emp.EMPTester.transform.position, transform.position);
        GameObject[] LightSource = GameObject.FindGameObjectsWithTag("Light");

        foreach (GameObject tgo in LightSource)
        {
<<<<<<< HEAD
            Debug.Log("Checking GO:" + tgo.name + " has a disance of " + Vector3.Distance(emp.EMPTester.transform.position, tgo.transform.position) + " comparing with " + emp.radius);
=======
            //Debug.Log("Checking GO:" + tgo.name + " has a disance of " + Vector3.Distance(emp.EMPTester.transform.position, tgo.transform.position) + " comparing with " + emp.radius);
>>>>>>> 827137cdd6958d129e58adb87fc0d8b1e7326ede

            if (Vector3.Distance(emp.EMPTester.transform.position, tgo.transform.position) < emp.radius)
            {
                Light tmpLight = tgo.GetComponent<Light>();
                MeshRenderer tempMR = tgo.GetComponent<MeshRenderer>();
                FogLight tempFL = tgo.GetComponent<FogLight>();
                MeshRenderer tmpchild = tgo.GetComponentInChildren<MeshRenderer>();
                LightRandomFlicker lft = tgo.GetComponent<LightRandomFlicker>();
                ParticleSystem Ps = tgo.GetComponent<ParticleSystem>();

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
                if (Ps != null)
                {

                    Ps.Clear();
                }
<<<<<<< HEAD

=======
                 
>>>>>>> 827137cdd6958d129e58adb87fc0d8b1e7326ede


                AreaLight tmpLight2 = tgo.GetComponent<AreaLight>();
                MeshRenderer tempMR2 = tgo.GetComponent<MeshRenderer>();
                FogLight tempFL2 = tgo.GetComponent<FogLight>();
                MeshRenderer tmpchild2 = tgo.GetComponentInChildren<MeshRenderer>();
                LightRandomFlicker lft2 = tgo.GetComponent<LightRandomFlicker>();
                ParticleSystem Ps1 = tgo.GetComponent<ParticleSystem>();

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
                if (Ps1 != null)
                {

                    Ps1.Clear();
                }

                TubeLight tmpLight3 = tgo.GetComponent<TubeLight>();
                MeshRenderer tempMR3 = tgo.GetComponent<MeshRenderer>();
                FogLight tempFL3 = tgo.GetComponent<FogLight>();
                MeshRenderer tmpchild3 = tgo.GetComponentInChildren<MeshRenderer>();
                LightRandomFlicker lft3 = tgo.GetComponent<LightRandomFlicker>();
                ParticleSystem Ps2 = tgo.GetComponent<ParticleSystem>();

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
                if (Ps2 != null)
                {

                    Ps2.Clear();
                }


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
            ParticleSystem Ps = tgo.GetComponent<ParticleSystem>();
            if (tmpLight != null)
<<<<<<< HEAD
                tmpLight.enabled = true;
=======
                 tmpLight.enabled = true;
>>>>>>> 827137cdd6958d129e58adb87fc0d8b1e7326ede
            if (tempMR != null)
                tempMR.enabled = true;
            if (tempFL != null)
                tempFL.enabled = true;
            if (tmpchild != null)
                tmpchild.enabled = true;
            if (lft != null)
            {
                lft.enabled = true;
                lft.flickerTime = 0;
            }
            if (Ps != null)
                Ps.Play();


            AreaLight tmpLight2 = tgo.GetComponent<AreaLight>();
            MeshRenderer tempMR2 = tgo.GetComponent<MeshRenderer>();
            FogLight tempFL2 = tgo.GetComponent<FogLight>();
            MeshRenderer tmpchild2 = tgo.GetComponentInChildren<MeshRenderer>();
            LightRandomFlicker lft2 = tgo.GetComponent<LightRandomFlicker>();
            ParticleSystem Ps2 = tgo.GetComponent<ParticleSystem>();

            if (tmpLight2 != null)
                tmpLight2.enabled = true;
            if (tempMR2 != null)
                tempMR2.enabled = true;
            if (tempFL2 != null)
                tempFL2.enabled = true;
            if (tmpchild2 != null)
                tmpchild2.enabled = true;
            if (lft2 != null)
            {
                lft2.enabled = true;
                lft2.flickerTime = 0;
            }
            if (Ps2 != null)
                Ps2.Play();


            TubeLight tmpLight3 = tgo.GetComponent<TubeLight>();
            MeshRenderer tempMR3 = tgo.GetComponent<MeshRenderer>();
            FogLight tempFL3 = tgo.GetComponent<FogLight>();
            MeshRenderer tmpchild3 = tgo.GetComponentInChildren<MeshRenderer>();
            LightRandomFlicker lft3 = tgo.GetComponent<LightRandomFlicker>();
            ParticleSystem Ps3 = tgo.GetComponent<ParticleSystem>();

            if (tmpLight3 != null)
                tmpLight3.enabled = true;
            if (tempMR2 != null)
                tempMR3.enabled = true;
            if (tempFL3 != null)
                tempFL3.enabled = true;
            if (tmpchild3 != null)
                tmpchild3.enabled = true;
            if (lft3 != null)
            {
                lft3.enabled = true;
                lft3.flickerTime = 0;
            }
            if (Ps3 != null)
                Ps3.Play();


        }

    }
}


