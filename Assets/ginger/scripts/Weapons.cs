using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public GameObject gun;
    public GameObject wrench;
    public GameObject mop;
    public GameObject scope;
    public GameObject syringe;
    playerController player;
    public Camera cam;

    float damage;
    
    public Animator anim;

    void Update()
    {
        

        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1 && gun.activeSelf)
            {
                Fire();              
            }
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1 && wrench.activeSelf)
            {
                anim.SetTrigger("hit");
            }
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1 && syringe.activeSelf)
        {
            player.health -= 10;

        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
         {
                 gun.SetActive(false);
                 wrench.SetActive(false);
                 mop.SetActive(false);
                 syringe.SetActive(false);
         }    

        if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                 gun.SetActive(false);
                 wrench.SetActive(true);
                 mop.SetActive(false);
                 syringe.SetActive(false);
            }

        if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                     gun.SetActive(true);
                     wrench.SetActive(false);
                     mop.SetActive(false);
                     syringe.SetActive(false);
            }
        if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                gun.SetActive(false);
                wrench.SetActive(false);
                mop.SetActive(true);
                syringe.SetActive(false);
            }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            gun.SetActive(false);
            wrench.SetActive(false);
            mop.SetActive(false);
            syringe.SetActive(true);
        }

        if (Input.GetMouseButton(3) && gun.activeSelf)
            {
                scope.SetActive(true);
                cam.fieldOfView = 40;              
            }
        else
            {
                scope.SetActive(false);
                cam.fieldOfView = 60;            
            }
            
    }
	
	void Fire()
    {
            var bullet = (GameObject)Instantiate(bulletPrefab,
                bulletSpawn.position, bulletSpawn.rotation);

            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;
            
            Destroy(bullet, 2.0f);
    }
}
