using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponClient
{
    private List<Sword> swordsProducts = new List<Sword>();
    private List<Axe> axesProducts = new List<Axe>();
    private List<Dagger> daggerProducts = new List<Dagger>();
    private List<Magic> magicProducts = new List<Magic>();

    private AbstractWeaponFactory factory;

    public WeaponClient(AbstractWeaponFactory factory)
    {
        this.factory = factory;
    }

    public void CreateWeapon(WeaponType weaponType,int rarity, int level)
    {
        switch (weaponType)
        {
            case WeaponType.Axe:
                axesProducts.Add(factory.CreateAxe(rarity, level));
                break;
            case WeaponType.Sword:
                break;
            case WeaponType.Dagger:
                break;
            case WeaponType.Magic:
                break;
            default: return;
        }
    }

    public AbstractWeaponProduct ReturnAllWeapons()
    {
        return axesProducts[0]; // THIS IS TEST, REturn just first axe
    }
}
