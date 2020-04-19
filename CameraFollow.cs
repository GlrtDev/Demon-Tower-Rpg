using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject followTarget;
    private void Update()
    {
        iTween.MoveUpdate(gameObject, new Vector3(followTarget.transform.position.x, followTarget.transform.position.y,-10), 0.5f);
    }
}
