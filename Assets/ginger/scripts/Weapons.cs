using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public Transform raySpawn;
    public GameObject gun;
    public GameObject wrench;
    public GameObject mop;
    public GameObject scope;
    public GameObject syringe;
<<<<<<< HEAD
    //public ammoCount ammoCT;


=======
<<<<<<< HEAD
    public ammoCount ammoCT;
    playerController player;
    AudioSource shoot;
    public AudioClip gunshot;
    public Camera cam;

    public int ammo = 10;
    
    public Animator anim;

     void Start()
    {
        shoot = GetComponent<AudioSource>();
=======
>>>>>>> chelsey
    public playerController player;

    public AudioClip wrenchSwing;
    public AudioClip syringeSound;
    public AudioClip mopSound;

    public Camera cam;

    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    private LineRenderer laserLine;
    private float nextFire;
    private AudioSource Audio;

    public int ammo = 10;
    public int gunDamage = 30;
    public float fireRate = .2f;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Animator anim;

<<<<<<< HEAD

     void Start()
=======
    void Start()
>>>>>>> chelsey
    {
        
        laserLine = GetComponent<LineRenderer>();
        Audio = GetComponent<AudioSource>();
<<<<<<< HEAD

=======
>>>>>>> dd8dfaef0e9daff8a170e1076208b8dfc96cab28
>>>>>>> chelsey
    }

    void Update()
    {
<<<<<<< HEAD
=======
<<<<<<< HEAD
        ammoCT.count = ammo;
=======
>>>>>>> dd8dfaef0e9daff8a170e1076208b8dfc96cab28
>>>>>>> chelsey

        //ammoCT.count = ammo;
        
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1 && gun.activeSelf && Time.time > nextFire) 
        {
                if (ammo > 0 )
                {
<<<<<<< HEAD
                    Fire();
                }
=======
<<<<<<< HEAD
                shoot.PlayOneShot(gunshot, 1f);
                    Fire();
            }
                              
=======
                    Fire();
                }
                             
>>>>>>> dd8dfaef0e9daff8a170e1076208b8dfc96cab28
>>>>>>> chelsey
            }
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1 && wrench.activeSelf)
            {
                anim.Play("wrench swing");
                Audio.PlayOneShot(wrenchSwing);
            
            }
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1 && syringe.activeSelf)
        {
            anim.Play("syringe attack");
            player.health -= 10;
            Audio.PlayOneShot(syringeSound);

        }

        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1 && mop.activeSelf)
        {
            Audio.PlayOneShot(mopSound);
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

        if (Input.GetMouseButton(1) && gun.activeSelf)
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
<<<<<<< HEAD
=======
<<<<<<< HEAD
        var bullet = (GameObject)Instantiate(bulletPrefab,
            bulletSpawn.position, bulletSpawn.rotation);
            
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 100;
        ammo--;
        Destroy(bullet, 2.0f);
=======
>>>>>>> chelsey
        anim.Play("gun shoot");
        nextFire = Time.time + fireRate;
        Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(.5f, .5f, .0f));
        Vector3 lineOrigin = cam.ViewportToWorldPoint(new Vector3(.5f, .5f, .0f));
        Debug.DrawRay(lineOrigin, cam.transform.forward * weaponRange, Color.gray);
        RaycastHit hit;
        laserLine.SetPosition(0, raySpawn.position);
<<<<<<< HEAD

=======
>>>>>>> chelsey
        ammo--;
        StartCoroutine(ShotEffect());
       if(Physics.Raycast(rayOrigin,cam.transform.forward,out hit,weaponRange))
        {
            laserLine.SetPosition(1, hit.point);
            stats hp = hit.collider.GetComponent<stats>();
            if(hp != null)
            {
                hp.Damage(gunDamage);
                anim.Play("gun hit");
            }
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * hitForce);
            }
        }
       else
        {
            laserLine.SetPosition(1, rayOrigin + (cam.transform.forward * weaponRange));
        }
    }

    private IEnumerator ShotEffect()
    {
        Audio.Play();
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
        
>>>>>>> dd8dfaef0e9daff8a170e1076208b8dfc96cab28
    }
}


