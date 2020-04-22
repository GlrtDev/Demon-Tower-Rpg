using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWeaponFactory
{
    public abstract Sword CreateSword(int rarity, int level);
    public abstract Magic CreateMagic(int rarity, int level);
    public abstract Axe CreateAxe(int rarity, int level);
    public abstract Dagger CreateDagger(int rarity, int level);
}
