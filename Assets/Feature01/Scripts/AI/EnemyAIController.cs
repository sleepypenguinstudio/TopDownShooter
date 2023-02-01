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
    NavMeshAgent agent;
    [SerializeField] Transform centrePoint;
    [SerializeField] float range;//range of what
    [SerializeField] float shootingInterval = 1.0f;
    float timeSinceLastShot;
    Vector3 lastPlayerPosition;



    protected override void Awake()
    {
        base.Awake();
        OwnerBullet = "Enemy";
        FieldOfView = GetComponent<FieldOfView>();
        ShootSystem = GetComponent<ShootSystem>();
        agent = GetComponent<NavMeshAgent>();


    }

    void Update()
    {

       VisiblityDetection();
      

    }

    void VisiblityDetection() // enemy movement, player chase, enemy shoot, enemy look at player
    {
         if (FieldOfView.canSeePlayer)
        {

            //  this.transform.rotation = EnemyMovementController.EnemyLook(FieldOfView.PlayerReference.transform,this.transform).rotation;

            //MovementController.Look((FieldOfView.PlayerReference.transform.position-transform.position));

            Look();


            timeSinceLastShot += Time.deltaTime;
            if (timeSinceLastShot >= shootingInterval)
            {
                ShootSystem.PlayerShoot(EnemybulletSpawnPosition, PlayerPosition.position - EnemybulletSpawnPosition.position);
                timeSinceLastShot = 0;
            }


            Move(PlayerPosition);

            lastPlayerPosition = PlayerPosition.position;

        }

        else if (Vector3.Distance(transform.position, lastPlayerPosition) > 0.1f && lastPlayerPosition != Vector3.zero)
        {
            Debug.Log("ashchi!!!!");
            agent.SetDestination(lastPlayerPosition);
            // Move(lastPlayerPosition);
        }
        else
        {
            lastPlayerPosition = Vector3.zero;
            Debug.Log("still Moving");
            Move();

        }

    }

    void SoundDetection() // needs work
    {
        if(FieldOfView.canHearPlayer)
        {
            Move(PlayerPosition);
            
        }
        // else{

        //     Move();
        // }
    }

    protected override void Look()
    {
        base.Look();
        transform.LookAt(FieldOfView.playerRef.transform);
    }


    protected override void Move()
    {

        base.Move();

        if (agent.remainingDistance <= agent.stoppingDistance) //done with path
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
            {
                agent.SetDestination(point); //need update for main game 
            }
        }


    }

    public void Move(Transform playerPosition)
    {
        Vector3 UpdatedPlayerPosition = new Vector3(playerPosition.position.x - Random.Range(3f, 8f), playerPosition.position.y, playerPosition.position.z - Random.Range(3f, 8f));
        agent.SetDestination(UpdatedPlayerPosition); 
                            
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





