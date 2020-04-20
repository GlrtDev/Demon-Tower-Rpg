using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWeaponFactory
{
    public abstract Sword CreateSword();
    public abstract Magic CreateMagic();
    public abstract Axe CreateAxe();
    public abstract Dagger CreateDagger();
}
