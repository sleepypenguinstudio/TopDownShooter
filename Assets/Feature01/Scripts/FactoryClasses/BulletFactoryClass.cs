using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactoryClass 
{

    Dictionary<string, BulletAbstractClasses> bullets = new Dictionary<string, BulletAbstractClasses>()
    {
        {"red", new RedBullet()},
        {"green",new GreenBullet()}
    };
   
    public BulletAbstractClasses getBulletType(string bullet)
    {

        return bullets[bullet];
    }
}
