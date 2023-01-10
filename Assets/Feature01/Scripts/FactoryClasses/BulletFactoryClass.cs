using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class BulletFactoryClass 
{

    Dictionary<PolarityManager.PlayerState, BulletAbstractClasses> bullets = new Dictionary<PolarityManager.PlayerState, BulletAbstractClasses>()
    {
       {PolarityManager.PlayerState.Ninja, Resources.Load<GameObject>("Prefab/PurpleBullet").GetComponent<BulletAbstractClasses>()},
       {PolarityManager.PlayerState.General,Resources.Load<GameObject>("Prefab/RedBullet").GetComponent<BulletAbstractClasses>()},
       {PolarityManager.PlayerState.Tank,Resources.Load<GameObject>("Prefab/GreenBullet").GetComponent<BulletAbstractClasses>()}
    };
   
    public BulletAbstractClasses GetBulletType(PolarityManager.PlayerState playerState)
    {
        return bullets[playerState];

        
    }
}

