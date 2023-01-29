using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAIController : CharacterAbstractController
{

    [SerializeField] private FieldOfView FieldOfView;
    
    [SerializeField] ShootSystem ShootSystem;
    [SerializeField] Transform EnemybulletSpawnPosition;
    [SerializeField] Transform PlayerPosition;

    [SerializeField]float shootingInterval=1.0f;
    float timeSinceLastShot;

    protected override void Awake()
    {
        base.Awake();
        OwnerBullet = "Enemy";
        FieldOfView = GetComponent<FieldOfView>();
        ShootSystem = GetComponent<ShootSystem>();
        Agent = GetComponent<NavMeshAgent>();


    }




    // Update is called once per frame
    void Update()
    {

        if (FieldOfView.IsPlayerVisible)
        {

            //  this.transform.rotation = EnemyMovementController.EnemyLook(FieldOfView.PlayerReference.transform,this.transform).rotation;

            //MovementController.Look((FieldOfView.PlayerReference.transform.position-transform.position));


            transform.LookAt(FieldOfView.PlayerReference.transform);



            timeSinceLastShot += Time.deltaTime;
            if (timeSinceLastShot >= shootingInterval)
            {
                ShootSystem.PlayerShoot(EnemybulletSpawnPosition, PlayerPosition.position - EnemybulletSpawnPosition.position);
                timeSinceLastShot = 0;
            }
            



            Move(PlayerPosition);



        
       

         
        }


         else
        {

            Move();

        }




        
    }

           protected override void Move()
    {

        base.Move();

        if (Agent.remainingDistance <= Agent.stoppingDistance) //done with path
        {
            Vector3 point;
            if (RandomPoint(CentrePoint.position, Range, out point)) //pass in our centre point and radius of area
            {
                //Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                Agent.SetDestination(point); //need update for main game 
            }
        }


    }

    public void Move(Transform playerPosition)
    {
         if (Agent.remainingDistance <= Agent.stoppingDistance) //done with path
        {
            
           // if (RandomPoint(CentrePoint.position, Range, out point)) //pass in our centre point and radius of area
            //{
                //Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                Vector3 UpdatedPlayerPosition = new Vector3(playerPosition.position.x - 5f, playerPosition.position.y, playerPosition.position.z);
                Agent.SetDestination(UpdatedPlayerPosition); //need update for main game 
            //}
        }
        
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }




            

  





    }

    



