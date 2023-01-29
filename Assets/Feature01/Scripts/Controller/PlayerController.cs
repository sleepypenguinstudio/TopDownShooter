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

    Transform playerTransform;
    

    Vector3 playerMoveInput;
    //Vector3 playerLookInput;


    public Vector2 movementInput;

    public Vector2 getDirection;
   

 



    [SerializeField] float playerSpeed = 30.0f;
   

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        playerTransform = this.transform;
     
        
    }


    private void FixedUpdate()
    {


        //cursorPosition = gamepadCursor.getCursorPosition();



        // gamepadCursor.moveCursorPosition(getDirection,_cursorSpeed);
        // movementController.PlayerLook(cursorPosition);
       //cursorPosition = playerFootInput.getMousePosition();
       
        
       Move();

    }

    protected override void Move()
    {
        
        base.Move();
        MovementController.PlayerMove(MovementInput,PolarityManager.MovementSpeed);
    }



}
