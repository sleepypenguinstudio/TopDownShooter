using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : BulletAbstractClasses
{
    public override void BulletProperties()
    {
        base.BulletProperties();
        GetComponent<MeshRenderer>().sharedMaterial.color = Color.red;
    }

}
