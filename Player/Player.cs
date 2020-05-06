using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public WeaponClient weaponClient;
    

    private void Awake()
    {
        weaponClient = new WeaponClient(new WeaponFactory());
        weaponClient.CreateWeapon(WeaponType.Dagger, 0, 0);
        weaponClient.CreateWeapon(WeaponType.Dagger, 1, 5);
        weaponClient.CreateWeapon(WeaponType.Sword, 0, 2);
        weaponClient.CreateWeapon(WeaponType.Sword, 1, 6);
        weaponClient.CreateWeapon(WeaponType.Sword, 1, 11);
        weaponClient.CreateWeapon(WeaponType.Axe, 0, 2);
    }
}
