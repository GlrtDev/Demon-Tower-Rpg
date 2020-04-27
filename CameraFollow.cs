using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject followTarget;
    private void Update()
    {
        iTween.MoveUpdate(gameObject,iTween.Hash( 
            "x" ,followTarget.transform.position.x,
            "y", followTarget.transform.position.y,
            "time" ,1.5f));
    }
}
