using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public WeaponClient weaponClient;
    public AbstractWeaponProduct equipedWeapon;

    private void Start()
    {
        weaponClient = new WeaponClient(new WeaponFactory());
        weaponClient.CreateWeapon(WeaponType.Axe, 0, 0);
        equipedWeapon = weaponClient.ReturnAllWeapons();
    }
}
