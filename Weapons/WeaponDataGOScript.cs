using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDataGOScript : MonoBehaviour
{
    public Hashtable weaponHash;
    private GameObject GroundCrackObject;

    public void SpawnCrack()
    {
        GroundCrackObject = Resources.Load<GameObject>((string)weaponHash["CrackPath"]);
        Debug.Log("spawn");
        GameObject.Instantiate(GroundCrackObject, gameObject.transform.position, Quaternion.Euler(0,0,Random.Range(0,180)));
    }
}
