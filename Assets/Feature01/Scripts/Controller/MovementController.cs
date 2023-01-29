using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{


    public bool canDash = true;
    public bool isDashing;
    [SerializeField]float dashingDistance = 70f;
    float dashingTime = 0.2f;
    [SerializeField]float dashingCooldown = 1f;
    [SerializeField] private TrailRenderer trailRenderer;



    private Rigidbody _Rigidbody;

    private void Awake()
    {
        _Rigidbody = GetComponent<Rigidbody>();
    }

   

    public void PlayerMove(Vector2 movementInput, float speed)
    {
        Vector3 playerMoveInput = new Vector3(movementInput.x , 0.0f, movementInput.y);
        _Rigidbody.velocity = playerMoveInput*speed;
    }

    public void PlayerLook(Vector3 getDirection)
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


        _Rigidbody.MoveRotation(targetRotation);


    }

    
    public IEnumerator Dash()
    {

        if (canDash && !isDashing) {

            canDash = false;
            isDashing = true;
            _Rigidbody.useGravity = false;
            Vector3 updatedDashDirection = transform.forward;

            //_rigidbody.velocity = playerTransfrom.forward*dashingDistance;
            Debug.Log("Dashging now " );
            _Rigidbody.AddForce(updatedDashDirection * dashingDistance, ForceMode.Impulse);
            trailRenderer.emitting = true;
            yield return new WaitForSeconds(dashingTime);
            trailRenderer.emitting = false;
            _Rigidbody.useGravity = true;
            isDashing = false;
            yield return new WaitForSeconds(dashingCooldown);

            canDash = true;

        }
    }

    public void Dash(int i)
    {

        if (canDash && !isDashing)
        {

            canDash = false;
            isDashing = true;
            _Rigidbody.useGravity = false;
            Vector3 updatedDashDirection = transform.forward;

            //_rigidbody.velocity = playerTransfrom.forward*dashingDistance;
            Debug.Log("Dashging now ");
            _Rigidbody.AddForce(updatedDashDirection * dashingDistance, ForceMode.Impulse);
            trailRenderer.emitting = true;
            
            trailRenderer.emitting = false;
            _Rigidbody.useGravity = true;
            isDashing = false;
            

            canDash = true;

        }
    }




}
