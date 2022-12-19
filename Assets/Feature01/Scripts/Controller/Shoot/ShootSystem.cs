using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] PlayerOnFootInput playerFootInput;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] public GameObject bulletGameObject;

    //Rigidbody rbBullet;


    private void Awake()
    {
        //rbBullet = bulletGameObject.GetComponent<Rigidbody>();
        playerFootInput = GetComponent<PlayerOnFootInput>();
    }

    public  void playerShoot(Vector3 mousePosition)
    {



        //GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject();

        //if (bullet != null)
        //{
        //    bullet.GetComponent<Rigidbody>().velocity = (playerLookPosition - this.transform.position).normalized * bulletSpeed;
        //}



        Vector3 playerLookPosition = mousePosition + Vector3.up * transform.position.y;
        GameObject firedBullet = Instantiate(bulletGameObject, spawnPoint.position,Quaternion.identity);
       firedBullet.GetComponent<Rigidbody>().velocity = (playerLookPosition-this.transform.position).normalized *bulletSpeed;
       
    }


    public void selectBulletType(string bulletName)
    {

        BulletFactoryClass bulletFactoryClass = new BulletFactoryClass();
        BulletAbstractClasses bulletAbstractClasses = bulletFactoryClass.getBulletType(bulletName);
        bulletAbstractClasses.InitializeBullet(bulletGameObject);
        //ObjectPooler.SharedInstance.setPooledObject(bulletGameObject);


    }
}
