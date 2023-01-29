using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : CharacterAbstractController
{
    Rigidbody _rigidbody;
    [SerializeField] PlayerOnFootInput playerFootInput;
    [SerializeField] PlayerInput playerInput;
   


    Transform playerTransform;
    

    protected override void Awake()
    {
        base.Awake();
        playerFootInput = GetComponent<PlayerOnFootInput>();
       
        OwnerBullet = "Player";
        

    }


    Vector3 playerMoveInput;
    //Vector3 playerLookInput;



    public Vector2 MovementInput;



    public Vector2 getDirection;
   

 



   // [SerializeField] float playerSpeed = 30.0f;

   


    private void FixedUpdate()
    {


        //cursorPosition = gamepadCursor.getCursorPosition();



        // gamepadCursor.moveCursorPosition(getDirection,_cursorSpeed);
        // movementController.PlayerLook(cursorPosition);
       //cursorPosition = playerFootInput.getMousePosition();
       
        
       Move();
       Look();
    }

    protected override void Move()
    {
        
        base.Move();
        movementController.PlayerMove(MovementInput,PolarityManager.MovementSpeed);
    }

    protected override void Look()
    {
        base.Look();
        movementController.PlayerLook(getDirection);
    }

}
