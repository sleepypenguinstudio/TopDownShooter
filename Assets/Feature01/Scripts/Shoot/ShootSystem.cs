using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 50f;
   [SerializeField] PlayerOnFootInput playerFootInput;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject bulletGameObject;
    Rigidbody rbBullet;


    private void Awake()
    {
        rbBullet = bulletGameObject.GetComponent<Rigidbody>();
        playerFootInput = GetComponent<PlayerOnFootInput>();
    }

    public  void playerShoot(Vector3 mousePosition)
    {
        Vector3 playerLookPosition = playerFootInput.getMousePosition() + Vector3.up * transform.position.y;
        Instantiate(bulletGameObject, spawnPoint.position,Quaternion.identity);
        rbBullet.velocity = bulletSpeed *(mousePosition-playerLookPosition);

    }


    public void selectBulletType(string bulletName)
    {

        BulletFactoryClass bulletFactoryClass = new BulletFactoryClass();
        BulletAbstractClasses bulletAbstractClasses = bulletFactoryClass.getBulletType(bulletName);
        bulletAbstractClasses.selectBullet(bulletGameObject);


    }
}
