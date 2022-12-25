using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{


   
   
    Vector3 playerMoveInput;

    public void PlayerMove(Vector2 movementInput, float speed,Rigidbody _rigidbody)
    {
        playerMoveInput = new Vector3(movementInput.x * _rigidbody.mass * speed, 0.0f, movementInput.y * _rigidbody.mass * speed);
        _rigidbody.AddForce(playerMoveInput,ForceMode.Force);


    }

    public void PlayerLook(Vector3 mousePosition)
    {
        Vector3 playerLookPosition = mousePosition + Vector3.up * transform.position.y;
        transform.LookAt(playerLookPosition);
    }




   
}
