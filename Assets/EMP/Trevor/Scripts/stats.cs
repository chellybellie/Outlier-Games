using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class stats : MonoBehaviour
{

    public Text crewname;
    public Image health;
    public Animator anim;
    public Animator enemyanim;

    private AudioSource sound;
    public AudioClip wrenchHit;
    public float hp;
    public string crewName;
    public int scanType;
    string[] scanOptions = new string[]
    {
        "enemy", "crew", "item"
    };
    int typeSelect = 0;
    public int itemType;
    string GenerateName()
    {
        int nameGen;
        nameGen = (int)(Random.Range(0, 15));
        string ret = "ENTER NAME";
        switch (nameGen)
        {
            case 0:
                ret = "Morgan Yu";
                break;
            case 1:
                ret = "Edison Jadin";
                break;
            case 2:
                ret = "Darwin Vanlith";
                break;
            case 3:
                ret = "Sock Kinton";
                break;
            case 4:
                ret = "Malcolm Sharpey";
                break;
            case 5:
                ret = "Weldon Stasny";
                break;
            case 6:
                ret = "Herschel Rackham";
                break;
            case 7:
                ret = "Linwood Raymond";
                break;
            case 8:
                ret = "Malik Hohstadt";
                break;
            case 9:
                ret = "Arden Foxwell";
                break;
            case 10:
                ret = "Lenard Gammon";
                break;
            case 11:
                ret = "[ERROR]";
                break;
            case 12:
                ret = "ghDREEEEkl    &'ael50";
                break;
            case 13:
                ret = "join_us";
                break;
            case 14:
                ret = "leavetheflesh";
                break;
            case 15:
                ret = "enemy.tga";
                break;
            default:
                break;
        }
        return ret;
    }

    string SetName(int i)
    {
        string ret = "[UNASSIGNED]";
        switch (i)
        {
            case 0:
                ret = "9mm Round";
                break;
            case 1:
                ret = "Wrench";
                break;
            case 2:
                ret = "Bandage";
                break;
            case 3:
                ret = "Medkit";
                break;
            case 4:
                ret = "P226 Handgun";
                break;
            case 5:
                ret = "Netrunner Mag Monthly";
                break;
            case 6:
                ret = "Security Chipset - 1";
                break;
            case 7:
                ret = "Security Chipset - 2";
                break;
            case 8:
                ret = "Security Chipset - 3";
                break;
            case 9:
                ret = "Security Chipset - S";
                break;
            case 10:
                ret = "Gross Sandwich";
                break;
            default:
                break;
        }
        return ret;
    }

    void Start () {
        hp = 100;
        sound = GetComponent<AudioSource>();

        switch (scanType)
        {
            case 0:
                crewName = GenerateName();
                break;
            case 1:
                crewName = GenerateName();
                break;
            case 2:
                crewName = SetName(itemType);
                hp = 0;
                Debug.Log("item");
                break;
        }
        
	}
	
	// Update is called once per frame
	void Update ()
    {

        // health.fillAmount = (hp / 100);
        //crewname.text = crewName;
       
       


        if (hp <= 0)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
            foreach (GameObject enemy in enemies)
            {
                NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
                if (!agent)
                    continue;
                agent.isStopped = true;
                enemyanim.Play("die");
            }
        } 
        
	}
    public void Damage (int damageAmount)
    {
        hp -= damageAmount;

        StartCoroutine(ANIMPLAY());

    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("syringe"))
        {
            anim.Play("syringe hit");
            hp -= 10;
            StartCoroutine(ANIMPLAY());
        }
        if (col.gameObject.CompareTag("wrench"))
        {
            anim.Play("wrench hit");
            sound.PlayOneShot(wrenchHit);
            hp -= 10;
            StartCoroutine(ANIMPLAY());
        }
    }

    IEnumerator ANIMPLAY()
    {
        enemyanim.Play("take hit");
        yield return new WaitForSeconds(2f);
    }

}
