using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarityManager : MonoBehaviour
{


    public float MaxHealth;
    public float CurrentHealth;
    public float MovementSpeed;
    public Color PlayerColor;
    public Stats CurrentPlayerStats;
    public PlayerState CurrentPlayerState;

    [SerializeField] ShootSystem ShootSystem;
    [SerializeField] PlayerController PlayerController;


    Dictionary<PlayerState, Stats> PlayerStatesSelection = new Dictionary<PlayerState, Stats>();
    
   


    private void Awake()
    {
        PlayerStatesSelection =  new Dictionary<PlayerState, Stats>()
        {
        {PlayerState.Ninja, Resources.Load<Stats>("ScriptableObjects/Ninja") },
        {PlayerState.Tank, Resources.Load<Stats>("ScriptableObjects/Tank") },
        {PlayerState.General, Resources.Load<Stats>("ScriptableObjects/General")}
        };

        CurrentPlayerStats = PlayerStatesSelection[PlayerState.General];
        CurrentPlayerState = PlayerState.General;

        MaxHealth = CurrentPlayerStats.MaxHealth;
        MovementSpeed = CurrentPlayerStats.MovementSpeed;
        CurrentHealth = 100f;
        PlayerColor = CurrentPlayerStats.PlayerColor;
        ShootSystem.SelectBulletType();
        PlayerController.SetPlayerBody();
    }

    



    public void SetPlayerState(PlayerState playerState)
    {
        PlayerState OldState = CurrentPlayerState;
        

        CurrentPlayerState = playerState;
        CurrentPlayerStats = PlayerStatesSelection[playerState];
        

        MaxHealth = CurrentPlayerStats.MaxHealth;
        MovementSpeed = CurrentPlayerStats.MovementSpeed;
        PlayerColor = CurrentPlayerStats.PlayerColor;

        CurrentHealth = CalculateCurrentHealth(OldState,CurrentPlayerState,CurrentHealth);
        Debug.Log("CurrentMaxHealth: "+MaxHealth+"CurrentMovementSpeed"+MovementSpeed);
        ShootSystem.SelectBulletType();
        PlayerController.SetPlayerBody();
        
        
        

    }


    private float CalculateCurrentHealth(PlayerState oldState,PlayerState newState,float _currentHealth)
    {
        Debug.Log("BeforeHealth: "+_currentHealth);
        float currentHealth = (_currentHealth * PlayerStatesSelection[newState].MaxHealth / PlayerStatesSelection[oldState].MaxHealth);
        Debug.Log("CurrentHealth: "+ currentHealth);
        return currentHealth;
    }


    public enum PlayerState
    {
        Ninja,
        General,
        Tank
    }


}
