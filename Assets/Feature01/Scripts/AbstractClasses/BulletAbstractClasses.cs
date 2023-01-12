using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class BulletAbstractClasses : MonoBehaviour
{
    [SerializeField] protected Color Color;
    public virtual void BulletProperties()
    {
        GetComponent<MeshRenderer>().sharedMaterial.color = Color;
    }
}
