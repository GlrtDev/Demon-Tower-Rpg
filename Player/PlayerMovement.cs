using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public const float MOVE_SPEED = 5f;
    // Start is called before the first frame update

    public Joystick joystick;
    public Rigidbody2D rb;

    Vector2 movement;
    public Animator animator;

    private void Start()
    {
        joystick =  GameObject.Find("Fixed Move Joystick").GetComponent<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;
        float spd = movement.sqrMagnitude;
        animator.SetFloat("Speed", spd);
        animator.SetFloat("AnimationMvntSpeed", 0.4f + 0.6f * spd);
        if (movement.x != 0)
        {
            if (movement.x > 0)
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            else
                transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MOVE_SPEED * Time.fixedDeltaTime);
    }

   
}
