using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAi : MonoBehaviour
{

    [SerializeField] private FieldOfView FieldOfView;
    [SerializeField] private EnemyMovementController EnemyMovementController;
    [SerializeField] ShootSystem ShootSystem;
    [SerializeField] Transform EnemybulletSpawnPosition;
    [SerializeField] Transform PlayerPosition;


    [SerializeField] private EnemyState currentEnemyState;
   

    

    // Update is called once per frame
    void Update()
    {

        if (FieldOfView.IsPlayerVisible)
        {

            this.transform.rotation = EnemyMovementController.EnemyLook(FieldOfView.PlayerReference.transform,this.transform).rotation;

            
            ShootSystem.EnemyShoot(currentEnemyState.EnemyBullet,EnemybulletSpawnPosition, PlayerPosition);

            

         
        }




        
    }






}
