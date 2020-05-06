using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public Player player;
    public Joystick joystick;
    public Animator animator;
    public ParticleSystem[] particleSystems = new ParticleSystem[2];
    private Vector2 attackDir;
    float nextAttackTime;
    private Transform transform;

    private void Start()
    {
        transform = gameObject.transform;
    }

    void Update()
    {
        if (player.weaponClient.equipedWeapon != null) {
            attackDir.x = joystick.Horizontal;
            attackDir.y = joystick.Vertical;

            if (((attackDir.sqrMagnitude > 0.9f) && Time.time >= nextAttackTime) || (attackDir.sqrMagnitude != 0.0f && player.weaponClient.equipedWeapon.GetType() == typeof(Dagger)))
            {
                animator.SetBool("Attacking", true);
                foreach (ParticleSystem particle in particleSystems)
                    particle.enableEmission = true;
                Vector3 currentPosition = new Vector3(transform.position.x, transform.position.y + 2, 0);

                //check attack speed stat
                player.weaponClient.equipedWeapon.Attack(currentPosition, attackDir);
                if (player.weaponClient.equipedWeapon.GetType() != typeof(Dagger))
                    nextAttackTime = Time.time + 1f / player.weaponClient.equipedWeapon.GetAttackRate(); //TO DO make it in function
            }
            else if (attackDir.sqrMagnitude == 0)
            {
                animator.SetBool("Attacking", false);
                foreach (ParticleSystem particle in particleSystems)
                    particle.enableEmission = false;
            }
        }
    }
}