using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBullet : BulletAbstractClasses
{
    public PolarityManager.PlayerState BulletState;

    public override void BulletProperties()
    {
        base.BulletProperties();
     BulletState = PolarityManager.PlayerState.Tank;

    }


}
