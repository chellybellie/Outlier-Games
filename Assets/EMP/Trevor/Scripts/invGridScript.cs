using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class invGridScript : MonoBehaviour {

    public Vector3 invPos;
    public GameObject emptyPrefab;
    public GameObject[,] visibleGrid = new GameObject[12, 10];
    public string[,] inventory = new string[12, 10]; //x and y are position, z is itemID
    public bool invChanged = false;

	void Start () {
        invPos = gameObject.transform.position + new Vector3(-500, -450, 0);
        InitInventory();
        DrawGrid(invPos, inventory);
	}
	
	// Update is called once per frame
	void Update () {
        if(invChanged)
        {
            RefreshGrid(visibleGrid);
        }

        
    }

    void DrawGrid(Vector3 origin, string[,] grid)
    {
        for(int i = 0; i < 12; ++i)
        {
            for(int j = 0; j < 10; ++j)
            {
                GameObject g = Instantiate(emptyPrefab, origin + new Vector3(i * 100, j * 100, 0), Quaternion.identity, gameObject.transform);
                g.name = "slot - " + i.ToString() + ", " + j.ToString();
                visibleGrid[i, j] = g;

                if(inventory[i,j] != "none")
                {
                    visibleGrid[i, j].GetComponentInChildren<Text>().text = inventory[i, j];
                }
                
            }
        }
    }

    void RefreshGrid(GameObject[,] vis)
    {
        invChanged = false;
        for (int i = 0; i < 12; ++i)
        {
            for (int j = 0; j < 10; ++j)
            {
                Destroy(visibleGrid[i, j]);
            }
        }
        DrawGrid(invPos, inventory);
    }


    void InitInventory()
    {
        for (int i = 0; i < 12; ++i)
        {
            for (int j = 0; j < 10; ++j)
            {
                inventory[i, j] = "empty";
            }
        }
    }

    public void AddItem(GameObject item)
    {
        
    }

    public void RemoveItem(GameObject item)
    {
        
    }

    public void MoveItem()
    {

    }
}
