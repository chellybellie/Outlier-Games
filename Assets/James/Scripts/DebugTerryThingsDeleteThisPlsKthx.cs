using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTerryThingsDeleteThisPlsKthx : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }
}
