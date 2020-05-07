using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponClient
{
    // maybe change to single list
    private List<Sword> swordsProducts = new List<Sword>();
    private List<Axe> axesProducts = new List<Axe>();
    private List<Dagger> daggerProducts = new List<Dagger>();
    private List<Magic> magicProducts = new List<Magic>();

    private AbstractWeaponFactory factory;

    public AbstractWeaponProduct equipedWeapon;
    private AbstractWeaponProduct[] selectedWeapons = new AbstractWeaponProduct[2];

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
                swordsProducts.Add(factory.CreateSword(rarity, level));
                break;
            case WeaponType.Dagger:
                daggerProducts.Add(factory.CreateDagger(rarity, level));
                break;
            case WeaponType.Magic:
                break;
            default: return;
        }
    }

    public IEnumerable<AbstractWeaponProduct> ReturnAllWeapons()
    {
        List<AbstractWeaponProduct> allWeapons = new List<AbstractWeaponProduct>();
        allWeapons.AddRange(swordsProducts);
        allWeapons.AddRange(axesProducts);
        allWeapons.AddRange(daggerProducts);
        //allWeapons.AddRange(swordsProducts);
        return allWeapons; 
    }

    public void EquipWeapon( AbstractWeaponProduct weapon)
    {
        var otherWeapons = ReturnAllWeapons();
        foreach (AbstractWeaponProduct otherWeapon in otherWeapons)
            otherWeapon.gameObject.SetActive(false);
        equipedWeapon = weapon;
    }
}
