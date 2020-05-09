using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        yield return new WaitForEndOfFrame();
        player.position = gameObject.transform.position;
    }
}
