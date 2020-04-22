using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFactory : AbstractWeaponFactory
{
    public override Axe CreateAxe(int rarity, int level)
    {
        return new Axe(rarity, level);
    }

    public override Dagger CreateDagger(int rarity, int level)
    {
        return new Dagger(rarity, level);
    }

    public override Magic CreateMagic(int rarity, int level)
    {
        return new Magic(rarity, level);
    }

    public override Sword CreateSword(int rarity, int level)
    {
        return new Sword(rarity, level);
    }
}
