using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MeleeWeapon
{
    public Sword(int rarity, int level) // the enemy level
    {
        base.Instantiate(WeaponType.Sword);
        int Number = (level / 10) % 10;
        itemStats["Type"] = WeaponType.Sword;
        itemStats["WeaponNumber"] = Number;
        itemStats["Rarity"] = rarity;
        itemStats["Name"] = "swor"; // TO DO name generator
        itemStats["Damage"] = 7 + ((0.35f * rarity) * level) + (level * 1);
        itemStats["AttackRate"] = 1.1f + (level * 0.01f);
        itemStats["SpritePath"] = "Sprites/Weapons/Swords/sword" + Number + "-" + rarity + "-level" + itemStats["WeaponLevel"];
        itemStats["IconPath"] = ""; // TO DO icons
        itemStats["trailStartColXY"] = new Vector2Int(27, 85);
        itemStats["trailEndColXY"] = new Vector2Int(27, 70);
        itemStats["trailWidth"] = 0.16f + (int)itemStats["WeaponLevel"] * 0.02f; // wpn level
        Initialize();
    }

    public override void Attack(Vector3 currentPosition, Vector2 attackDirection)
    {
        Initialize();
        //gameObject.transform.position = currentPosition;
        Vector3[] path = new Vector3[3];
        float animateTime = Random.Range(0.4f, 0.6f);
        iTween.RotateTo(gameObject, iTween.Hash(
            "z", Vector2.SignedAngle(new Vector2(0,1), attackDirection),
            "time", animateTime,
            "easetype", iTween.EaseType.easeInQuint));


        Debug.Log(Vector2.SignedAngle(new Vector2(0, 1), attackDirection));
        attackDirection *= 2;
        //if (Mathf.Abs(attackDirection.x) > Mathf.Abs(attackDirection.y))
            path = new Vector3[] {currentPosition,
            //new Vector3(currentPosition.x - attackDirection.x, currentPosition.y - attackDirection.y, currentPosition.z),
            new Vector3(currentPosition.x + 2*attackDirection.x, currentPosition.y + 2*attackDirection.y, currentPosition.z)
        };
        //else
        //    path = new Vector3[2] {
        //    new Vector3(currentPosition.x + attackDirection.y, currentPosition.y + 1.5f*attackDirection.x, currentPosition.z),
        //    new Vector3(currentPosition.x + attackDirection.x, currentPosition.y + 1.5f*attackDirection.y, currentPosition.z)
        //};

        

        iTween.MoveTo(gameObject, iTween.Hash(
            "oncomplete", "SpawnCrack",
            "oncompletetarget", gameObject,
            "path", path,
            "easetype", iTween.EaseType.easeInQuint,
            "time", animateTime
            ));
    }

}
