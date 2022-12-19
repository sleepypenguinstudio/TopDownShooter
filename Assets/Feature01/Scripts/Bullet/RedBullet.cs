using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : BulletAbstractClasses
{
    Color redColor = Color.red;
    
    public override void InitializeBullet(GameObject bullet)
    {
        bullet.GetComponent<MeshRenderer>().sharedMaterial.color = redColor;

    }
}
