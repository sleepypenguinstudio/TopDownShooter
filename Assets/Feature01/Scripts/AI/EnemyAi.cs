using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAi : MonoBehaviour
{

    private Vector3 StartingPosition;
    Vector3 RoamingPosition;


    public NavMeshAgent NavmeshAgent;
    public float StartWaitTime = 4f;
    public float TimeToRotate = 2f;
    public float WalkingSpeed = 6;
    public float RunningSpeed = 9;

    public float ViewRadius = 15f;
    public float ViewAngle = 90f;
    public LayerMask PlayerMask;
    public LayerMask ObstacleMask;
    public float MeshResolution = 1f;
    public int EdgeIterations = 4;
    public float EdgeDistance = 0.5f;


    public Transform[] WayPoints;
    


    // Start is called before the first frame update
    void Start()
    {
        StartingPosition = this.transform.position;
        RoamingPosition = GetPetrolPosition();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }







    private Vector3 GetPetrolPosition()
    {
      

        return StartingPosition+RandomPosition()*Random.Range(10,70f);

    }

    private Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }




}
