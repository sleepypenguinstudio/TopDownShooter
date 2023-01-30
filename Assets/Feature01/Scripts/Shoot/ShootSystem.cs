using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;
 
    
    [SerializeField] public GameObject BulletGameObject;
    //[SerializeField] public GameObject EnemyBulletGameObject;
    [SerializeField] PolarityManager polarityManager;

    [SerializeField] int playerBulletLayer;
    [SerializeField] int enemyBulletLayer;
    



    //Rigidbody rbBullet;


    private void Awake()
    {
        polarityManager = GetComponent<PolarityManager>();
        

        
    }

    public  void PlayerShoot(Transform SpawnPosition,Vector3 DirectionToShoot)
    {



        //TO DO
        SelectBulletType();




       GameObject FiredBullet = Instantiate(BulletGameObject, SpawnPosition.position,Quaternion.identity);
      
       FiredBullet.GetComponent<BulletAbstractClasses>().PolarityManager = GetComponent<PolarityManager>();
       FiredBullet.GetComponent<Rigidbody>().velocity = DirectionToShoot *bulletSpeed;
       FiredBullet.layer = GetComponent<CharacterAbstractController>().OwnerBullet == "Player" ? playerBulletLayer : enemyBulletLayer;
        
       
    }


    public void SelectBulletType()//witout this
    {

        
        BulletGameObject = BulletFactoryClass.Instance.GetBulletType(polarityManager.CurrentPlayerState); //taking the currentplayer state and selecting bullet based on that 
        BulletGameObject.GetComponent<BulletAbstractClasses>().BulletProperties();
        //ObjectPooler.SharedInstance.setPooledObject(bulletGameObject);


    }

  

   
    




    










}
