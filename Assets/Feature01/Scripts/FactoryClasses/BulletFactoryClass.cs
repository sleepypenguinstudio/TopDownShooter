using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactoryClass 
{

    Dictionary<PolarityManager.PlayerState, BulletAbstractClasses> bullets = new Dictionary<PolarityManager.PlayerState, BulletAbstractClasses>()
    {
        {PolarityManager.PlayerState.Ninja, new BlueBullet()},
        {PolarityManager.PlayerState.General,new RedBullet()},
        {PolarityManager.PlayerState.Tank,new GreenBullet()}
    };
   
    public BulletAbstractClasses GetBulletType(PolarityManager.PlayerState playerState)
    {

        return bullets[playerState];
    }
}
