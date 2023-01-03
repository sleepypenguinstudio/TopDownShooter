using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerOnFootInput : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }
   
    

    private Camera mainCamera;

    PlayerController playerController;
    ShootSystem shootSystem;

    [SerializeField] PlayerInput playerInput;

   
    private void Awake()
    {
        mainCamera = Camera.main;
        playerController = GetComponent<PlayerController>();
        shootSystem =  GetComponent<ShootSystem>();
    }

    private void OnEnable()
    {
        
        playerInput = new PlayerInput();
        playerInput.PlayerOnFoot.Enable();

        playerInput.PlayerOnFoot.Movement.performed += SetMove;
        playerInput.PlayerOnFoot.Movement.canceled += SetMove;


        playerInput.PlayerOnFoot.Fire.performed += setShoot;
        playerInput.PlayerOnFoot.Fire.Enable();

        playerInput.PlayerOnFoot.GetDirection.performed += SetDirection;
        playerInput.PlayerOnFoot.GetDirection.canceled += SetDirection;


    }

    private void SetDirection(InputAction.CallbackContext context)
    {
        playerController.getDirection = context.ReadValue<Vector2>();
      



        //Vector2 moveVectorLeft = context.ReadValue<Vector2>();
        //Vector2 currentPosition = Mouse.current.position.ReadValue();
        //Vector2 newPosition = currentPosition + moveVectorLeft*50f*Time.deltaTime;
        //Mouse.current.WarpCursorPosition(newPosition);
    }

    private void setShoot(InputAction.CallbackContext context)
    {
       
        shootSystem.playerShoot();
        
    }

    private void OnDisable()
    {
        playerInput.PlayerOnFoot.Movement.performed -= SetMove;
        playerInput.PlayerOnFoot.Movement.canceled -= SetMove;

        playerInput.PlayerOnFoot.GetDirection.performed -= SetDirection;
        playerInput.PlayerOnFoot.GetDirection.canceled -= SetDirection;

        playerInput.PlayerOnFoot.Fire.Disable();

        
        playerInput.PlayerOnFoot.Disable();
    }


    private void SetMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {

        playerController.movementInput = context.ReadValue<Vector2>();
      // MoveInput=context.ReadValue<Vector2>();
    }

   

    //public Vector3 getMousePosition()
    //{

    //    Vector2 mousePosition = playerInput.PlayerOnFoot.MousePosition.ReadValue<Vector2>();

    //    Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x,mousePosition.y,mainCamera.transform.position.y));

        
    //    return mouseWorldPosition;

    //}


   
}
