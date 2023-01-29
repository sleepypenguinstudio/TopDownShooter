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
            

         
        }




        
    }






}
