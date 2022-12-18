using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] PlayerOnFootInput PlayerFootInput;
    [SerializeField] PlayerInput pl;
    Vector3 playerMoveInput;
    //Vector3 playerLookInput;



 



    [SerializeField] float speed = 30.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
     
        
    }


    private void FixedUpdate()
    {
        
        PlayerMove();
        PlayerLook();
        rb.AddForce(playerMoveInput,ForceMode.Force);


      
    }

   

    private void PlayerMove()
    {
       
        playerMoveInput = new Vector3(PlayerFootInput.MoveInput.x * rb.mass * speed, 0.0f, PlayerFootInput.MoveInput.y * rb.mass * speed);
        
    }

    private void PlayerLook()
    {
        Vector3 playerLookPosition = PlayerFootInput.getMousePosition() + Vector3.up * transform.position.y;


           transform.LookAt(playerLookPosition);
    }


    
}
