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


    public Vector3 mousePosition;

 



    [SerializeField] float speed = 30.0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
     
        
    }


    private void FixedUpdate()
    {

        mousePosition = playerFootInput.getMousePosition();




        movementController.PlayerMove(movementInput,speed,_rigidbody);      
        movementController.PlayerLook(mousePosition);
       
        
        


      
    }

   

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
