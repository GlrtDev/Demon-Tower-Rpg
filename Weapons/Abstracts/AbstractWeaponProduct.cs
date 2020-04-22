using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType {Sword, Axe , Dagger ,Magic, Undefined }

public abstract class AbstractWeaponProduct 
{
    public GameObject gameObject { get; protected set; } // Weapon GO attached to this script
                                                         //public int damage { get; protected set; } // TODO make more stats , evan aray
    protected SpriteRenderer spriteRenderer;
    protected Hashtable itemStats = new Hashtable();

    public virtual void Instantiate(WeaponType weaponType)
    {
        gameObject = GameObject.Instantiate(Resources.Load<GameObject>("Sprites/Weapons/WeaponBase"));
        itemStats.Add("Type", WeaponType.Undefined);
        itemStats.Add("Name", "");
        itemStats.Add("Damage", 0);
        itemStats.Add("AttackRate", 0.0f); //attack speed
        itemStats.Add("SpritePath", "");
        itemStats.Add("IconPath", "");
        //go add abstract weapon product. go.awp = this;

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public virtual void CombineWith(AbstractWeaponProduct other)
    {
        // prevent self interaction
        if (other == this)
            return;

        if (other.gameObject == null)
            return;
        
        //this.damage += (int)(0.1f * other.damage);
        GameObject.Destroy(other.gameObject);
        other = null;
    }

    public virtual void Attack(Vector3 currentPosition,Vector2 attackDirection) { } // position where to spawn weapon

    public virtual void Update() { }

    public float GetAttackRate()
    {
        return (float)itemStats["AttackRate"];
    }
}
