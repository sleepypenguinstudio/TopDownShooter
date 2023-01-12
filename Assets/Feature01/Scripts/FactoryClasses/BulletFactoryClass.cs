using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class BulletFactoryClass : MonoBehaviour
{


    public static BulletFactoryClass Instance { get; private set; }
    Dictionary<PolarityManager.PlayerState, GameObject> Bullets;


    private void Awake()
    {
        Instance = this;


        Bullets = new Dictionary<PolarityManager.PlayerState, GameObject>()
    {
       {PolarityManager.PlayerState.Ninja, Resources.Load<GameObject>("Prefab/PurpleBullet")},
       {PolarityManager.PlayerState.General,Resources.Load<GameObject>("Prefab/RedBullet")},
       {PolarityManager.PlayerState.Tank,Resources.Load<GameObject>("Prefab/GreenBullet")}
    };
    }

    
   
    public GameObject GetBulletType(PolarityManager.PlayerState playerState)
    {
        return Bullets[playerState];

        
    }
}

