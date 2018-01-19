using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public GameObject pausemenu;
    public GameObject buttonpanel;
    public float speed = 20f;
    public Camera cam;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public GameObject gun;
    public GameObject wrench;
    public GameObject mop;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Pause()
    {
        pausemenu.SetActive(true);
        buttonpanel.SetActive(true);
        Time.timeScale = 0;
    }
   
    void Update ()
    {
        Vector3 pos = transform.position;

        if(Input.GetKey(KeyCode.W))
        {
            pos.z += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos.z -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += speed * Time.deltaTime;
        }
        transform.position = pos;
         transform.rotation = cam.transform.rotation;

        if (Input.GetKeyDown(KeyCode.P))
            {
                Pause();
            }
        
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1 && gun.activeSelf )
                   {
                       Fire();
                   }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            gun.SetActive(true);
            wrench.SetActive(false);
            mop.SetActive(false);
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gun.SetActive(false);
            wrench.SetActive(true);
            mop.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gun.SetActive(false);
            wrench.SetActive(false);
            mop.SetActive(true);
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
