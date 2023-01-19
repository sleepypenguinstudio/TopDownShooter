using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{



    public float Radius;
    [Range(0, 360)]
    public float Angle;

    public GameObject PlayerReference;

    public LayerMask TargetMask;
    public LayerMask ObstructionMask;

    public bool IsPlayerVisible;



 

    private void Start()
    {
        
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds WaitingTime = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return WaitingTime;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] ObjectsinRange = Physics.OverlapSphere(transform.position, Radius, TargetMask);

        if (ObjectsinRange.Length != 0)
        {
            Transform Target = ObjectsinRange[0].transform;
            Vector3 DirectionToTarget = (Target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, DirectionToTarget) < Angle / 2)
            {
                float DistanceToTarget = Vector3.Distance(transform.position, Target.position);

                if (!Physics.Raycast(transform.position, DirectionToTarget, DistanceToTarget, ObstructionMask))
                {
                    IsPlayerVisible = true;
               
                }
                else
                {
                    IsPlayerVisible = false;
                }
            }
            else
            {
                IsPlayerVisible = false;
            }
        }
        else if (IsPlayerVisible)
        {
            IsPlayerVisible = false;
        }
    }
}
