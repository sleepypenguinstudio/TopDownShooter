using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody _rigidbody;
    [SerializeField] PlayerOnFootInput playerFootInput;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] MovementController movementController;
    

    Vector3 playerMoveInput;
    //Vector3 playerLookInput;


    public Vector2 movementInput;

    public Vector2 getDirection;
   

 



    [SerializeField] float playerSpeed = 30.0f;
   

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
     
        
    }


    private void FixedUpdate()
    {


        //cursorPosition = gamepadCursor.getCursorPosition();



        // gamepadCursor.moveCursorPosition(getDirection,_cursorSpeed);
        // movementController.PlayerLook(cursorPosition);
       //cursorPosition = playerFootInput.getMousePosition();
       
        
        movementController.PlayerMove(movementInput,playerSpeed,_rigidbody);

        movementController.PlayerLook(getDirection, _rigidbody, this.transform);





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
