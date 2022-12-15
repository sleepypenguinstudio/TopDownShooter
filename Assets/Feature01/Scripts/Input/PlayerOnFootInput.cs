using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerOnFootInput : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }
    

    private Camera mainCamera;

    PlayerInput playerInput;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        playerInput = new PlayerInput();
        playerInput.PlayerOnFoot.Enable();

        playerInput.PlayerOnFoot.Movement.performed += SetMove;
        playerInput.PlayerOnFoot.Movement.canceled += SetMove;

     
    }

    
    private void OnDisable()
    {
        playerInput.PlayerOnFoot.Movement.performed -= SetMove;
        playerInput.PlayerOnFoot.Movement.canceled -= SetMove;

     

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
