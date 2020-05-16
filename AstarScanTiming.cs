using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstarScanTiming : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Scan");
    }

    IEnumerator Scan()
    {
        yield return new WaitForSeconds(0.5f);
        AstarPath.active.Scan();
    }
}
