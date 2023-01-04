using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{


    public bool canDash = true;
    public bool isDashing;
    float dashingDistance = 24f;
    float dashingTime = 0.2f;
    float dashingCooldown = 1f;




   
    Vector3 playerMoveInput;

    public void PlayerMove(Vector2 movementInput, float speed,Rigidbody _rigidbody)
    {
        playerMoveInput = new Vector3(movementInput.x * _rigidbody.mass * speed, 0.0f, movementInput.y * _rigidbody.mass * speed);

        _rigidbody.MovePosition(_rigidbody.position+playerMoveInput*Time.fixedDeltaTime);
        
      //  _rigidbody.AddForce(playerMoveInput,ForceMode.Force);


    }

    public void PlayerLook(Vector2 getDirection,Rigidbody _rigidbody,Transform transform)
    {
        //Vector3 playerLookPosition = getDirection + Vector3.up * transform.position.y;
        //transform.LookAt(playerLookPosition);

        Vector3 playerLookPosition = new Vector3(getDirection.x,0,getDirection.y).normalized;

        if (playerLookPosition == Vector3.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(playerLookPosition);

        targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.deltaTime);


        _rigidbody.MoveRotation(targetRotation);


    }

    
    public IEnumerator Dash(Rigidbody _rigidbody,Transform playerTransfrom)
    {
        Debug.Log("IN the coroutine");
        canDash = false;
        isDashing = true;
        _rigidbody.useGravity = false;
        _rigidbody.velocity = playerTransfrom.forward*dashingDistance;
        yield return new WaitForSeconds(dashingTime);
        Debug.Log("past the coroutine");
        _rigidbody.useGravity = true;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);

        canDash = true;
    }




   
}
