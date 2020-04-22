using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public Player player;
    public Joystick joystick;

    private Vector2 attackDir;
    float nextAttackTime;
    private Transform transform;

    private void Start()
    {
        transform = gameObject.transform;
    }

    void Update()
    {
        attackDir.x = joystick.Horizontal;
        attackDir.y = joystick.Vertical;
        if (Time.time >= nextAttackTime)
        {
            if (attackDir.sqrMagnitude != 0)
            {
                Vector3 currentPosition = new Vector3(transform.position.x, transform.position.y + 2, 0);

                //check attack speed stat
                player.equipedWeapon.Attack(currentPosition, attackDir);
                nextAttackTime = Time.time + 1f / player.equipedWeapon.GetAttackRate();
            }
        }
    }
}