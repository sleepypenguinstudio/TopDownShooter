using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDecision : MonoBehaviour
{


    Dictionary<PolarityManager.PlayerState, int> StateMaping;

    int[,] StateResult = new int[,] { 
        { 0, -1, 1 },
        { 1, 0 ,-1 }, 
        { -1, 1, 0 } 
    };





    private void Awake()
    {
        StateMaping = new Dictionary<PolarityManager.PlayerState, int>() {
            { PolarityManager.PlayerState.Ninja,0 },
            {PolarityManager.PlayerState.Tank,1 },
            {PolarityManager.PlayerState.General,2 }
        
        
        };
    }

    public int RetrieveDamageValue(PolarityManager.PlayerState characterState,PolarityManager.PlayerState bulletState)
    {

        int CharacterStateValue = StateMaping[characterState];
        int BulletStateValue = StateMaping[bulletState];

        return StateResult[CharacterStateValue,BulletStateValue];





    }








}
