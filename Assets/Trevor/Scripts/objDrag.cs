using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class objDrag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public Vector2 itemPos;
    public Vector3 lastPosition;
    public Vector2 itemSize;
    public invGridScript inv;
    public bool dragging;
    Vector3 mouseDelta;
    Vector3 mouseNew;
    Vector3 mouseLast;
	void Start () {
        itemSize = new Vector2(1, 2);
        inv = GetComponentInParent<invGridScript>();
        dragging = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.localPosition.x < -510)
        {
            gameObject.transform.Translate(Vector3.right * 50);
        }
        if (gameObject.transform.localPosition.x > 610)
        {
            gameObject.transform.Translate(Vector3.left * 50);
        }

        if (gameObject.transform.localPosition.y < -410)
        {
            gameObject.transform.Translate(Vector3.up * 50);
        }
        if (gameObject.transform.localPosition.y > 410)
        {
            gameObject.transform.Translate(Vector3.down * 50);
        }
        mouseLast = mouseNew;
        mouseNew = Input.mousePosition;
        mouseDelta = mouseNew - mouseLast;
		if(dragging)
        {
            transform.Translate(mouseDelta);
        }
       
	}

    public void ItemClick()
    {
        inv.MoveItem();
        gameObject.transform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
    }
    

    public void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
        gameObject.transform.localPosition = (gameObject.transform.localPosition - new Vector3(gameObject.transform.localPosition.x % 100, gameObject.transform.localPosition.y % 100, 0));
    }
}
