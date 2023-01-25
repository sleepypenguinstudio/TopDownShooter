using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageResolver : MonoBehaviour
{
    [SerializeField] float destroyAfterTime =5f;
    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(DestroyObjectAfterTime(destroyAfterTime));
    }

    IEnumerator DestroyObjectAfterTime(float destroyTime)
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(this.gameObject);
      //  this.gameObject.SetActive(false);
    }

   

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {

        

        PolarityManager targetState = other.gameObject.GetComponent<PolarityManager>();
        PolarityManager bulletState = this.gameObject.GetComponent<BulletAbstractClasses>().PolarityManager;


        int damageValue = StateDecision.Instance.RetrieveDamageValue(targetState.CurrentPlayerState,bulletState.CurrentPlayerState);

        //if (damageValue < 0)
        //{
        //    HealthManager.Instance.AddHealth(targetState.CurrentHealth,damageValue,);
        //}
        
        
        
        //Destroy(this.gameObject);
    }
}
