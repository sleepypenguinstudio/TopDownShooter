using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [SerializeField] float destryoAfterTime =5f;
    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(DestroyObjectAfterTime(destryoAfterTime));
    }

    IEnumerator DestroyObjectAfterTime(float destroyTime)
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(this.gameObject);
      //  this.gameObject.SetActive(false);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Destroy(this.gameObject);
    //}

   

    
}
