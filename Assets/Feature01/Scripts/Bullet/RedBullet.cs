using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : BulletAbstractClasses
{
    public PolarityManager.PlayerState BulletState;
    public override void BulletProperties()
    {
        base.BulletProperties();
        BulletState = PolarityManager.PlayerState.General;
    }

}
