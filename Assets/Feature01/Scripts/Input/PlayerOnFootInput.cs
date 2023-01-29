using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerOnFootInput : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }



    private Camera MainCamera;

    PlayerController playerController;
    ShootSystem shootSystem;
    [SerializeField] PolarityManager polarityManager;
    [SerializeField] Transform spawnPosition;
    [SerializeField] PlayerInput playerInput;


    private void Awake()
    {
        MainCamera = Camera.main;
        playerController = GetComponent<PlayerController>();
        shootSystem = GetComponent<ShootSystem>();
        polarityManager = GetComponent<PolarityManager>();
    }

    private void OnEnable()
    {

        playerInput = new PlayerInput();
        playerInput.PlayerOnFoot.Enable();

        playerInput.PlayerOnFoot.Movement.performed += SetMove;
        playerInput.PlayerOnFoot.Movement.canceled += SetMove;

        playerInput.PlayerOnFoot.GetDirection.performed += SetDirection;
        playerInput.PlayerOnFoot.GetDirection.canceled += SetDirection;



        playerInput.PlayerOnFoot.Fire.performed += SetShoot;
        playerInput.PlayerOnFoot.Fire.Enable();




        playerInput.PlayerOnFoot.Dash.performed += SetDash;
        playerInput.PlayerOnFoot.Dash.Enable();

        playerInput.PlayerOnFoot.General.performed += SetGeneralState;
        playerInput.PlayerOnFoot.General.Enable();


        playerInput.PlayerOnFoot.Ninja.performed += SetNinjaState;
        playerInput.PlayerOnFoot.Ninja.Enable();


        playerInput.PlayerOnFoot.Tank.performed += SetTankState;
        playerInput.PlayerOnFoot.Tank.Enable();




    }

    private void OnDisable()
    {
        playerInput.PlayerOnFoot.Movement.performed -= SetMove;
        playerInput.PlayerOnFoot.Movement.canceled -= SetMove;

        playerInput.PlayerOnFoot.GetDirection.performed -= SetDirection;
        playerInput.PlayerOnFoot.GetDirection.canceled -= SetDirection;

        playerInput.PlayerOnFoot.Fire.Disable();
        playerInput.PlayerOnFoot.Dash.Disable();

        playerInput.PlayerOnFoot.General.Disable();
        playerInput.PlayerOnFoot.Ninja.Disable();
        playerInput.PlayerOnFoot.Tank.Disable();

        playerInput.PlayerOnFoot.Disable();
    }



    private void SetTankState(InputAction.CallbackContext context)
    {
        polarityManager.SetPlayerState(PolarityManager.PlayerState.Tank);
    }

    private void SetNinjaState(InputAction.CallbackContext context)
    {
        polarityManager.SetPlayerState(PolarityManager.PlayerState.Ninja);
    }

    private void SetGeneralState(InputAction.CallbackContext context)
    {
        polarityManager.SetPlayerState(PolarityManager.PlayerState.General);
    }







    private void SetDirection(InputAction.CallbackContext context)
    {
        playerController.getDirection = context.ReadValue<Vector2>();




        //Vector2 moveVectorLeft = context.ReadValue<Vector2>();
        //Vector2 currentPosition = Mouse.current.position.ReadValue();
        //Vector2 newPosition = currentPosition + moveVectorLeft*50f*Time.deltaTime;
        //Mouse.current.WarpCursorPosition(newPosition);
    }

    private void SetShoot(InputAction.CallbackContext context)
    {


        shootSystem.PlayerShoot(spawnPosition, transform.forward);

    }


    private void SetDash(InputAction.CallbackContext context)
    {
        Debug.Log("ButtonPressed");
        playerController.Dash();
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