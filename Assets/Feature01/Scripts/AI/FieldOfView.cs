using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{



    public float radius;
    public float angle;


    public GameObject PlayerReference;

    public LayerMask TargetMask;
    public LayerMask ObstacleMask;

    public bool IsPlayerVisible;

    private void Start()
    {
        
    }
}
