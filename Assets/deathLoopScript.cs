using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class deathLoopScript : MonoBehaviour {

    public VideoPlayer deathTwo;
    public VideoPlayer deathOne;
    public float vidTimer;

	// Use this for initialization
	void Start () {
	            	
	}
	
	// Update is called once per frame
	void Update ()
    {
        vidTimer += Time.deltaTime;
        deathOne.loopPointReached += DeathOne_loopPointReached;
	}

    private void DeathOne_loopPointReached(VideoPlayer source)
    {
      
        deathTwo.Play();
        Destroy(deathOne);
    }
}
