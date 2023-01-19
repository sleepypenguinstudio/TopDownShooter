using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : CharacterAbstractController
{
  
    [SerializeField] PlayerOnFootInput PlayerFootInput;
    [SerializeField] PlayerInput PlayerInput;
    public Vector2 MovementInput;

    public Vector2 GetDirection;




    

    public Stats PlayerStats;





    


    private void FixedUpdate()
    {
        
        MovementController.Move(MovementInput,PolarityManager.MovementSpeed);

        MovementController.Look(GetDirection);
    }



}
