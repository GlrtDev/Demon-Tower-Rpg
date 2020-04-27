using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType {Sword, Axe , Dagger ,Magic, Undefined }

public abstract class AbstractWeaponProduct 
{
    public GameObject gameObject { get; protected set; } // Weapon GO attached to this script
                                                         //public int damage { get; protected set; } // TODO make more stats , evan aray
    protected SpriteRenderer spriteRenderer;
    protected TrailRenderer trailRenderer;
    protected Hashtable itemStats = new Hashtable();

    public GameObject GroundCrackObject { get; protected set; }
    public virtual void Instantiate(WeaponType weaponType)
    {
        //gameObject = GameObject.Instantiate(Resources.Load<GameObject>("Sprites/Weapons/WeaponBase"));
        itemStats.Add("Type", WeaponType.Undefined);
        itemStats.Add("Name", "");
        itemStats.Add("Damage", 0);
        itemStats.Add("AttackRate", 0.0f); //attack speed
        itemStats.Add("WeaponLevel", 0);
        itemStats.Add("Rarity", 0);
        itemStats.Add("WeaponNumber", 0);
        itemStats.Add("SpritePath", "");
        itemStats.Add("IconPath", "");
        itemStats.Add("CrackPath", "Prefabs/groundCrack");
        itemStats.Add("PrefabPath", "Prefabs/WeaponBase");
        itemStats.Add("trailStartColXY", new Color());
        itemStats.Add("trailEndColXY", new Color());
        itemStats.Add("trailWidth", 0.5f);
        //go add abstract weapon product. go.awp = this;

        //spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Initialize()
    {
        if (gameObject == null)
        {
            gameObject = GameObject.Instantiate(Resources.Load<GameObject>((string)itemStats["PrefabPath"]));
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            trailRenderer = gameObject.GetComponent<TrailRenderer>();
            spriteRenderer.sprite = Resources.Load<Sprite>((string)itemStats["SpritePath"]);
            WeaponDataGOScript weaponData = gameObject.GetComponent<WeaponDataGOScript>();
            weaponData.weaponHash = this.itemStats;
            trailRenderer.startColor = spriteRenderer.sprite.texture.GetPixel(((Vector2Int)itemStats["trailStartColXY"]).x, ((Vector2Int)itemStats["trailStartColXY"]).y); //bad
            trailRenderer.endColor = spriteRenderer.sprite.texture.GetPixel(((Vector2Int)itemStats["trailEndColXY"]).x, ((Vector2Int)itemStats["trailEndColXY"]).y); //bad
            trailRenderer.widthMultiplier = (float)itemStats["trailWidth"];
        }

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
