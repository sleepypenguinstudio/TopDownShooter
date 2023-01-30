using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{



    public float radius;
    [Range(0, 360)]
    public float angle;
    [Range(0, 360)]
    public float soundRadious;
    public float soundRange;

    public GameObject playerRef;
    // public GameObject glassWall;

    public Light spotLight;
    Color color1;


    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;
    public bool canHearPlayer;
    public Renderer soundArea;


    private void Start()
    {

        // StartCoroutine(FOVRoutine());
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    private void Update()
    {

        ColorUtility.TryParseHtmlString("#00FF00", out color1);


        if (canSeePlayer)
        {
            spotLight.color = Color.red;
            // if(GameObject.FindGameObjectWithTag("glassWall"))
            // {

            // }

        }
        else
        {

            spotLight.color = Color.blue;
        }

        if (canHearPlayer)
        {
            soundArea.material.color = new Color32(255, 0, 0, 25);
        }
        else
        {
            soundArea.material.color = new Color32(0, 255, 0, 25);
        }

    }


    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck(angle);
            FieldOfSound(soundRadious);
        }
    }

    private void FieldOfViewCheck(float viewAngle)
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < viewAngle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canSeePlayer = true;
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }

    private void FieldOfSound(float viewAngle)
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, soundRange, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            canHearPlayer = true;


        }
        else
            canHearPlayer = false;
    }


}
