using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] PlayerOnFootInput playerFootInput;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] public GameObject bulletGameObject;
    [SerializeField] PolarityManager PolarityManager;

    //Rigidbody rbBullet;


    private void Awake()
    {
        //rbBullet = bulletGameObject.GetComponent<Rigidbody>();
        playerFootInput = GetComponent<PlayerOnFootInput>();
    }

    public  void PlayerShoot(Transform SpawnPosition)
    {



        //GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject();

        //if (bullet != null)
        //{
        //    bullet.GetComponent<Rigidbody>().velocity = (playerLookPosition - this.transform.position).normalized * bulletSpeed;
        //}



        //Vector3 playerLookPosition = mousePosition + Vector3.up * transform.position.y;
        GameObject firedBullet = Instantiate(bulletGameObject, SpawnPosition.position,Quaternion.identity);
       firedBullet.GetComponent<Rigidbody>().velocity = transform.forward *bulletSpeed;
       
    }


    public void SelectBulletType()//witout this
    {

        
        bulletGameObject = BulletFactoryClass.Instance.GetBulletType(PolarityManager.CurrentPlayerState); //taking the currentplayer state and selecting bullet based on that 
        bulletGameObject.GetComponent<BulletAbstractClasses>().BulletProperties();
        //ObjectPooler.SharedInstance.setPooledObject(bulletGameObject);


    }
}
