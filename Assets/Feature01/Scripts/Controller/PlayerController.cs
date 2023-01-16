using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody _Rigidbody;
    [SerializeField] PlayerOnFootInput PlayerFootInput;
    [SerializeField] PlayerInput PlayerInput;
    [SerializeField] MovementController MovementController;

    Transform PlayerTransform;
    

    Vector3 playerMoveInput;
    //Vector3 playerLookInput;


    public Vector2 MovementInput;

    public Vector2 GetDirection;




    [SerializeField] PolarityManager PolarityManager;

    public Stats PlayerStats;
    
   

    private void Awake()
    {
        _Rigidbody = GetComponent<Rigidbody>();
        PlayerTransform = this.transform;
     
        
    }


    private void FixedUpdate()
    {


        //cursorPosition = gamepadCursor.getCursorPosition();



        // gamepadCursor.moveCursorPosition(getDirection,_cursorSpeed);
        // movementController.PlayerLook(cursorPosition);
       //cursorPosition = playerFootInput.getMousePosition();
       
        
        MovementController.PlayerMove(MovementInput,PolarityManager.MovementSpeed,_Rigidbody);

        MovementController.PlayerLook(GetDirection, _Rigidbody, this.transform);





    }



    public void PlayerDash()
    {
      
        StartCoroutine(MovementController.Dash(_Rigidbody,PlayerTransform,MovementInput));


    }


    public void SetPlayerBody(Color PlayerColor)
    {
        this.gameObject.GetComponent<MeshRenderer>().sharedMaterial.color = PlayerColor;
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
