using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCrack : MonoBehaviour
{
   
    void Start()
    {
        iTween.ScaleTo(gameObject, iTween.Hash(
            "delay", 1.0f,
            "time", 1.0f,
            "scale", Vector3.zero,
            "easetype", iTween.EaseType.easeInQuint,
            "oncomplete", "EndAnimation"));
    }


    void EndAnimation()
    {
        Destroy(gameObject);
    }
}
