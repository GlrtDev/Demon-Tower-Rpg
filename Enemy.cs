using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { melee, ranged, magic};

public class Enemy : MonoBehaviour
{

    public int tier = 1; // 1 - minion , 2 strong- minion , 3 sub-boss , 4 boss
    public int enemyLevel = 1; // based on floor level
    public int damage = 1;
    public EnemyType enemyType = EnemyType.melee;
    public int healthPoints;

    public static float zPos = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //prevent clipping
        transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
        zPos -= 0.0001f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetGold()
    {
        int gold = 10 + enemyLevel + (tier-1) * enemyLevel * 10;
        return gold;
    }
}
