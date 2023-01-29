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

    private void Awake()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {

            PolarityManager targetState = other.gameObject.GetComponent<PolarityManager>();
            PolarityManager bulletState = this.gameObject.GetComponent<BulletAbstractClasses>().PolarityManager;


            int damageValue = StateDecision.Instance.RetrieveDamageValue(targetState.CurrentPlayerState, bulletState.CurrentPlayerState);

           


            targetState.CurrentHealth = damageValue < 0 ? HealthManager.Instance.DamageHealth(targetState.CurrentHealth, -damageValue) : HealthManager.Instance.AddHealth(targetState.CurrentHealth, damageValue,targetState.MaxHealth); //based on the damageValue, it is adding or decreasing the health of the object the bullet hit. target state is the currentstate of the object that bullet hit.

           
            
            Debug.Log("Player Current Health: "+targetState.CurrentHealth);


         


            Debug.Log("Damage Value: "+damageValue);

        }
        
        //if (damageValue < 0)
        //{
        //    HealthManager.Instance.AddHealth(targetState.CurrentHealth,damageValue,);
        //}
        
        
        
        Destroy(this.gameObject);
    }
}
