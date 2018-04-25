using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class takeHitScript : MonoBehaviour {

    private Image hitImg;
    public Camera cam;
    public bool isHit;
    private float hitTime;
    public Vector3 resetCam;
	void Start () {
        hitImg = gameObject.GetComponent<Image>();
        hitTime = 0;
        resetCam = new Vector3(0, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.H))
        {
            TakeHit();
        }


		if(isHit)
        {
            hitTime -= Time.deltaTime;
            if(hitTime > 1)
            {
                cam.transform.localPosition = (resetCam + new Vector3((Random.Range(-.2f,.2f)) * (hitTime - .4f), (Random.Range(-.2f, .2f)) * (hitTime - .4f), 0));
            }
            else if(hitTime < 1)
            {
                cam.transform.localPosition = resetCam;
            }

            if (hitTime <= 0)
            {
                hitTime = 0;
                isHit = false;
            }
        }

        hitImg.color = new Color(hitImg.color.r, hitImg.color.g, hitImg.color.b, hitTime);
	}

    public void TakeHit()
    {
        isHit = true;
        hitTime = 1.2f;
    }
}
