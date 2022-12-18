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

    PlayerInput playerInput;

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

     
    }

    private void setShoot(InputAction.CallbackContext context)
    {
        Vector3 mousePosition = getMousePosition();

        
        shootSystem.playerShoot(mousePosition);
    }

    private void OnDisable()
    {
        playerInput.PlayerOnFoot.Movement.performed -= SetMove;
        playerInput.PlayerOnFoot.Movement.canceled -= SetMove;

        playerInput.PlayerOnFoot.Fire.Disable();

        
        playerInput.PlayerOnFoot.Disable();
    }


    private void SetMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
       MoveInput=context.ReadValue<Vector2>();
    }

   

    public Vector3 getMousePosition()
    {  
        
        return mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.transform.position.y));

    }

    


}
