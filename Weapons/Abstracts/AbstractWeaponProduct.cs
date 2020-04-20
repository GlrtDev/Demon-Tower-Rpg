using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType {Sword, Axe , Dagger ,Magic }

public abstract class AbstractWeaponProduct 
{
    public GameObject gameObject { get; protected set; } // Weapon GO made from prefab
    public int damage { get; protected set; } // TODO make more stats , evan aray

    public  void Instantiate(WeaponType weaponType)
    {
        gameObject = GameObject.
    }

    public void CombineWith(AbstractWeaponProduct other)
    {
        // prevent self interaction
        if (other == this)
            return;

        if (other.gameObject == null)
            return;

        this.damage += (int)(0.1f * other.damage);
        GameObject.Destroy(other.gameObject);
        other = null;
    }
}
