using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] PlayerOnFootInput playerFootInput;
    
    [SerializeField] public GameObject BulletGameObject;
    //[SerializeField] public GameObject EnemyBulletGameObject;
    [SerializeField] PolarityManager PolarityManager;

  


    //Rigidbody rbBullet;


    private void Awake()
    {
        PolarityManager = GetComponent<PolarityManager>();
    }

    public  void PlayerShoot(Transform SpawnPosition,Vector3 DirectionToShoot)
    {



        //TO DO
        SelectBulletType();


       GameObject FiredBullet = Instantiate(BulletGameObject, SpawnPosition.position,Quaternion.identity);
       FiredBullet.GetComponent<BulletAbstractClasses>().characterAbstractController = GetComponent<CharacterAbstractController>();
       FiredBullet.GetComponent<Rigidbody>().velocity = DirectionToShoot *bulletSpeed;
       
    }


    public void SelectBulletType()//witout this
    {

        
        BulletGameObject = BulletFactoryClass.Instance.GetBulletType(PolarityManager.CurrentPlayerState); //taking the currentplayer state and selecting bullet based on that 
        BulletGameObject.GetComponent<BulletAbstractClasses>().BulletProperties();
        //ObjectPooler.SharedInstance.setPooledObject(bulletGameObject);


    }

  

   
    




    










}
