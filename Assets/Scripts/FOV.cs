﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour { 

    public float viewRadius;
    [Range (0,360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal) {
            angleInDegrees += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
}