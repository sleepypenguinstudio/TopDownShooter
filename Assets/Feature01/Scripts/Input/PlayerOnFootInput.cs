using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerOnFootInput : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }
   
    

    private Camera MainCamera;

    PlayerController PlayerController;
    ShootSystem ShootSystem;
    [SerializeField]PolarityManager PolarityManager;
    [SerializeField] Transform SpawnPosition;
    [SerializeField] PlayerInput PlayerInput;

   
    private void Awake()
    {
        MainCamera = Camera.main;
        PlayerController = GetComponent<PlayerController>();
        ShootSystem =  GetComponent<ShootSystem>();
    }

    private void OnEnable()
    {
        
        PlayerInput = new PlayerInput();
        PlayerInput.PlayerOnFoot.Enable();

        PlayerInput.PlayerOnFoot.Movement.performed += SetMove;
        PlayerInput.PlayerOnFoot.Movement.canceled += SetMove;

        PlayerInput.PlayerOnFoot.GetDirection.performed += SetDirection;
        PlayerInput.PlayerOnFoot.GetDirection.canceled += SetDirection;



        PlayerInput.PlayerOnFoot.Fire.performed += SetShoot;
        PlayerInput.PlayerOnFoot.Fire.Enable();

       


        PlayerInput.PlayerOnFoot.Dash.performed += SetDash;
        PlayerInput.PlayerOnFoot.Dash.Enable();

        PlayerInput.PlayerOnFoot.General.performed += SetGeneralState;
        PlayerInput.PlayerOnFoot.General.Enable();


        PlayerInput.PlayerOnFoot.Ninja.performed += SetNinjaState;
        PlayerInput.PlayerOnFoot.Ninja.Enable();


        PlayerInput.PlayerOnFoot.Tank.performed += SetTankState;
        PlayerInput.PlayerOnFoot.Tank.Enable();




    }

    private void OnDisable()
    {
        PlayerInput.PlayerOnFoot.Movement.performed -= SetMove;
        PlayerInput.PlayerOnFoot.Movement.canceled -= SetMove;

        PlayerInput.PlayerOnFoot.GetDirection.performed -= SetDirection;
        PlayerInput.PlayerOnFoot.GetDirection.canceled -= SetDirection;

        PlayerInput.PlayerOnFoot.Fire.Disable();
        PlayerInput.PlayerOnFoot.Dash.Disable();

        PlayerInput.PlayerOnFoot.General.Disable();
        PlayerInput.PlayerOnFoot.Ninja.Disable();
        PlayerInput.PlayerOnFoot.Tank.Disable();

        PlayerInput.PlayerOnFoot.Disable();
    }



    private void SetTankState(InputAction.CallbackContext context)
    {
        PolarityManager.SetPlayerState(PolarityManager.PlayerState.Tank);
    }

    private void SetNinjaState(InputAction.CallbackContext context)
    {
        PolarityManager.SetPlayerState(PolarityManager.PlayerState.Ninja);
    }

    private void SetGeneralState(InputAction.CallbackContext context)
    {
        PolarityManager.SetPlayerState(PolarityManager.PlayerState.General); 
    }

   





    private void SetDirection(InputAction.CallbackContext context)
    {
        PlayerController.GetDirection = context.ReadValue<Vector2>();
      



        //Vector2 moveVectorLeft = context.ReadValue<Vector2>();
        //Vector2 currentPosition = Mouse.current.position.ReadValue();
        //Vector2 newPosition = currentPosition + moveVectorLeft*50f*Time.deltaTime;
        //Mouse.current.WarpCursorPosition(newPosition);
    }

    private void SetShoot(InputAction.CallbackContext context)
    {
        
        
        ShootSystem.PlayerShoot(SpawnPosition);
        
    }


    private void SetDash(InputAction.CallbackContext context)
    {
        Debug.Log("ButtonPressed");
        PlayerController.PlayerDash();
    }

   







    private void SetMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {

        PlayerController.MovementInput = context.ReadValue<Vector2>();
      // MoveInput=context.ReadValue<Vector2>();
    }

   

    //public Vector3 getMousePosition()
    //{

    //    Vector2 mousePosition = playerInput.PlayerOnFoot.MousePosition.ReadValue<Vector2>();

    //    Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x,mousePosition.y,mainCamera.transform.position.y));

        
    //    return mouseWorldPosition;

    //}


   
}
