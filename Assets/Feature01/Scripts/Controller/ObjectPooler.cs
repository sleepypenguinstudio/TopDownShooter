using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPooler : MonoBehaviour
{












   // // Not implemented or plugged anywhere. not finished.
   // public static ObjectPooler SharedInstance;
   // public List<GameObject> pooledObjects;
    
   // public int amountToPool;
   // [SerializeField] GameObject gameObjectToPool;

   // private void Awake()
   // {
   //     SharedInstance = this;
   // }
   // // Start is called before the first frame update
   // void Start()
   // {
   //     pooledObjects = new List<GameObject>();

   //     GameObject tmp;

   //     for (int i = 0; i < amountToPool; i++)
   //     {
   //         tmp = Instantiate(gameObjectToPool);
   //         tmp.SetActive(false);
   //         pooledObjects.Add(tmp);
   //     }

   // }

   //public GameObject GetPooledObject()
   // {
   //     for(int i = 0; i < amountToPool; i++)
   //     {
   //         if (!pooledObjects[i].activeInHierarchy)
   //         {
   //             return pooledObjects[i];
   //         }
   //     }
   //     return null;

   // }

   // public void SetPooledObject(GameObject objectToPool)
   // {

   //     GameObject tmp;

   //     for (int i = 0; i < amountToPool; i++)
   //     {
   //         tmp = Instantiate(objectToPool);
   //         tmp.SetActive(false);
   //         pooledObjects.Add(tmp);
   //     }

   // }
}
