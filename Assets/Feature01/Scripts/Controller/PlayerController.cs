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



    public Vector2 movementInput;



    public Vector2 getDirection;
   

 



    [SerializeField] float playerSpeed = 30.0f;

   


    private void FixedUpdate()
    {


        //cursorPosition = gamepadCursor.getCursorPosition();



        // gamepadCursor.moveCursorPosition(getDirection,_cursorSpeed);
        // movementController.PlayerLook(cursorPosition);
       //cursorPosition = playerFootInput.getMousePosition();
       
        
        movementController.Move(movementInput,playerSpeed);

        movementController.Look(getDirection);





    }



    

    //public void RotatePLayer(Vector2 inputForRotation)
    // {

    // }

    //private void PlayerMove()
    //{

    //    playerMoveInput = new Vector3(playerFootInput.MoveInput.x * _rigidbody.mass * speed, 0.0f, playerFootInput.MoveInput.y * _rigidbody.mass * speed);

    //}

    //private void PlayerLook()
    //{
    //    Vector3 playerLookPosition = playerFootInput.getMousePosition() + Vector3.up * transform.position.y;


    //       transform.LookAt(playerLookPosition);
    //}



}
