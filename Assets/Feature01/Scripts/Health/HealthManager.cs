using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public Stats CurrentStats;
    public Stats PreviousStats;


    public static HealthManager Instance { get; private set; }

    private void Awake()
    {
            Instance = this;       
    }


    public float AddHealth(float currentHealth,float powerUp,float maxHealth)
    {
       return (currentHealth+powerUp)>maxHealth? maxHealth:(currentHealth+powerUp);

    }



    public float DamageHealth(float currentHealth,float damage)
    {
        return (currentHealth - damage) < 0 ? 0 : currentHealth - damage;
    }



    public float CalculateCurrentHealth(float _currentHealth)
    {

        Debug.Log("BeforeHealth: " + _currentHealth);
        float currentHealth = (_currentHealth * CurrentStats.MaxHealth / PreviousStats.MaxHealth);
        Debug.Log("CurrentHealth: " + currentHealth);
        return currentHealth;
    }

    

}
