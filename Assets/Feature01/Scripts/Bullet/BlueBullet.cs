using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBullet : BulletAbstractClasses
{
    Color BlueColorBullet = Color.blue;


    public override void InitializeBullet(GameObject bullet)
    {
        bullet.GetComponent<MeshRenderer>().sharedMaterial.color = BlueColorBullet;

    }
}
