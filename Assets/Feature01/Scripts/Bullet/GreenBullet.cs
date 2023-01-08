using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBullet : BulletAbstractClasses
{
    Color GreenColorBullet = Color.green;
    
    
    public override void InitializeBullet(GameObject bullet)
    {
        bullet.GetComponent<MeshRenderer>().sharedMaterial.color = GreenColorBullet ;
        
    }
}
