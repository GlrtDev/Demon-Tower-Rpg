using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        StartCoroutine("SearchForPlayer");
    }
    private void FixedUpdate()
    {
        //iTween.MoveUpdate(gameObject,iTween.Hash( 
        //    "x" ,followTarget.transform.position.x,
        //    "y", followTarget.transform.position.y+1,
        //    "time" ,1.5f));
        if (followTarget)
        {
            Vector3 desiredPosition = followTarget.position + offset;
            Vector3 smothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
            transform.position = smothedPosition;
        }
    }

    IEnumerator SearchForPlayer()
    {
        yield return new WaitForSeconds(0.3f);
        followTarget = FindObjectOfType<Player>().transform;
        Debug.Log(followTarget);
        if (followTarget == null)
            StartCoroutine("SearchForPlayer");
    }
}
