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
       
    }

    public  void PlayerShoot(Transform SpawnPosition)
    {



        //GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject();

        //if (bullet != null)
        //{
        //    bullet.GetComponent<Rigidbody>().velocity = (playerLookPosition - this.transform.position).normalized * bulletSpeed;
        //}



        //Vector3 playerLookPosition = mousePosition + Vector3.up * transform.position.y;
       GameObject FiredBullet = Instantiate(BulletGameObject, SpawnPosition.position,Quaternion.identity);
       FiredBullet.GetComponent<Rigidbody>().velocity = transform.forward *bulletSpeed;
       
    }


    public void SelectBulletType()//witout this
    {

        
        BulletGameObject = BulletFactoryClass.Instance.GetBulletType(PolarityManager.CurrentPlayerState); //taking the currentplayer state and selecting bullet based on that 
        BulletGameObject.GetComponent<BulletAbstractClasses>().BulletProperties();
        //ObjectPooler.SharedInstance.setPooledObject(bulletGameObject);


    }

    public void EnemyShoot(GameObject EnemyBulletGameObject, Transform SpawnPosition,Transform PlayerPosition)
    {
        GameObject EnemyBullet = Instantiate(EnemyBulletGameObject, SpawnPosition.position, Quaternion.identity);

        EnemyBullet.GetComponent<Rigidbody>().velocity = (PlayerPosition.position - SpawnPosition.position).normalized * bulletSpeed;


    }

    public GameObject SelectEnemyBulletType(PolarityManager.PlayerState enemyState)
    {

        GameObject EnemyBulletGameObject = BulletFactoryClass.Instance.GetBulletType(enemyState);
        EnemyBulletGameObject.GetComponent<BulletAbstractClasses>().BulletProperties();
        return EnemyBulletGameObject;



    }
    




    










}
