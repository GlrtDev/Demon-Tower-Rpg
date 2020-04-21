using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public Player player;
    public Joystick joystick;

    public Vector2 attackDir;
    public Transform transform;

    private void Start()
    {
        transform = gameObject.transform;
    }

    void Update()
    {
        attackDir.x = joystick.Horizontal;
        attackDir.y = joystick.Vertical;
        if(attackDir.sqrMagnitude != 0)
        {
            Vector3 currentPosition = transform.position;
            
            player.equipedWeapon.Attack(currentPosition ,attackDir);
        }
    }
}