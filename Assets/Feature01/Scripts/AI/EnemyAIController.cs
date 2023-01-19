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


    protected override void Awake()
    {
        base.Awake();
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

           
            ShootSystem.PlayerShoot(EnemybulletSpawnPosition, PlayerPosition.position-EnemybulletSpawnPosition.position);
          

            

         
        }




        
    }






}
