using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour {

    public float hp;
    public string crewName;


    string GenerateName()
    {
        int nameGen;
        nameGen = (int)(Random.Range(0, 15));
        string ret = "ENTER NAME";
        switch (nameGen)
        {
            case 0:
                ret = "Fuck Trump";
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
                ret = "Linwood Racine";
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

    void Start () {
        hp = 100;
        crewName = GenerateName();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
