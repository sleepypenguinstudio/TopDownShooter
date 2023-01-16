using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    
    public Transform EnemyLook(Transform target,Transform ownTransform) {


        Vector3 LookAtPosition = target.position - ownTransform.transform.position;

        Quaternion UpdatedRotation = Quaternion.LookRotation(LookAtPosition,ownTransform.transform.up);

        //ownTransform.rotation = Quaternion.Slerp(ownTransform.rotation,UpdatedRotation,Time.deltaTime*1000);
        ownTransform.rotation = UpdatedRotation;
        return ownTransform;
    
    }
    


    





}
