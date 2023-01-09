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

    



    public void SetPlayerState(PlayerState playerState) // PlayerOnInput is setting the state when button is pressed using this function
    {
        PlayerState OldState = CurrentPlayerState;
        

        CurrentPlayerState = playerState;//the enum that dictates the state
        CurrentPlayerStats = PlayerStatesSelection[playerState];//based on the enum value of that particular state is retrieved from a dictionary. dictionary returns a scriptable object for that state
        

        MaxHealth = CurrentPlayerStats.MaxHealth;
        MovementSpeed = CurrentPlayerStats.MovementSpeed;
        PlayerColor = CurrentPlayerStats.PlayerColor;

        CurrentHealth = HealthManager.Instance.CalculateCurrentHealth(OldState,CurrentPlayerState,CurrentHealth,PlayerStatesSelection);
        Debug.Log("CurrentMaxHealth: "+MaxHealth+"CurrentMovementSpeed"+MovementSpeed);
        ShootSystem.SelectBulletType();
        PlayerController.SetPlayerBody();
        
        
        

    }


   


    public enum PlayerState
    {
        Ninja,
        General,
        Tank
    }


}
