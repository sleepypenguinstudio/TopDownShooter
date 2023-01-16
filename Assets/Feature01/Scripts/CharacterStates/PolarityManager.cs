using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

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


    //[SerializeField]Dictionary<PlayerState, Stats> PlayerStatesSelection = new Dictionary<PlayerState, Stats>();

    [SerializeField] public List<PlayerStateSelection> PlayerStateSelectionsList;
    
   


    private void Awake()
    {
        //PlayerStatesSelection =  new Dictionary<PlayerState, Stats>()
        //{
        //{PlayerState.Ninja, Resources.Load<Stats>("ScriptableObjects/Ninja") },
        //{PlayerState.Tank, Resources.Load<Stats>("ScriptableObjects/Tank") },
        //{PlayerState.General, Resources.Load<Stats>("ScriptableObjects/General")}
        //};

        CurrentPlayerStats = PlayerStateSelectionsList.First(r => r.PlayerState == PlayerState.General).Stats; //PlayerStatesSelection[PlayerState.General];
        CurrentPlayerState = PlayerState.General;

        MaxHealth = CurrentPlayerStats.MaxHealth;
        MovementSpeed = CurrentPlayerStats.MovementSpeed;
        CurrentHealth = MaxHealth;
        PlayerColor = CurrentPlayerStats.PlayerColor;
        ShootSystem.SelectBulletType();
        PlayerController.SetPlayerBody(PlayerColor);
    }

    



    public void SetPlayerState(PlayerState playerState) // PlayerOnInput is setting the state when button is pressed using this function
    {
        PlayerState OldState = CurrentPlayerState;


        HealthManager.Instance.PreviousStats = PlayerStateSelectionsList.First(r => r.PlayerState == OldState).Stats;




        CurrentPlayerState = playerState;//the enum that dictates the state
        CurrentPlayerStats = PlayerStateSelectionsList.First(r => r.PlayerState == playerState).Stats;//based on the enum value of that particular state is retrieved from a dictionary. dictionary returns a scriptable object for that state


        HealthManager.Instance.CurrentStats = CurrentPlayerStats;


        MaxHealth = CurrentPlayerStats.MaxHealth;
        MovementSpeed = CurrentPlayerStats.MovementSpeed;
        PlayerColor = CurrentPlayerStats.PlayerColor;

        CurrentHealth = HealthManager.Instance.CalculateCurrentHealth(CurrentHealth);
        Debug.Log("CurrentMaxHealth: "+MaxHealth+"CurrentMovementSpeed"+MovementSpeed);
        ShootSystem.SelectBulletType(); //setting bullet state
        PlayerController.SetPlayerBody(PlayerColor);
        
        
        

    }


   


    public enum PlayerState
    {
        Ninja,
        General,
        Tank
    }


}


[Serializable]
public class PlayerStateSelection
{

    public Stats Stats;
    public PolarityManager.PlayerState PlayerState;

}