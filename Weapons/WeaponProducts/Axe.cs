using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MeleeWeapon
{
    public Axe(int rarity, int level) 
    {
        int Number = (level / 10 ) % 10;
        base.Instantiate(WeaponType.Axe);
        itemStats["Type"] = WeaponType.Axe;
        itemStats["Name"] = WeaponNames[(int) WeaponType.Axe, Number*2 +rarity]; // TO DO name generator
        itemStats["Damage"] = 10 + ((0.4f * rarity) * level) + (level * 1);
        itemStats["AttackRate"] = 1 + (level * 0.01f);
        itemStats["SpritePath"] = "Sprites/Weapons/Axes/axe" + Number + "-" + rarity + "-level0";
        itemStats["IconPath"] = ""; // TO DO icons
        itemStats["trailStartColXY"] = new Vector2Int(16, 87);
        itemStats["trailEndColXY"] = new Vector2Int(20, 87);
        Initialize();
    }

    public override void Attack(Vector3 currentPosition, Vector2 attackDirection)
    {
        Initialize();
        //gameObject.transform.position = currentPosition;
        Vector3[] path = new Vector3[4];
        attackDirection *= 3;
        if(Mathf.Abs(attackDirection.x) > Mathf.Abs(attackDirection.y))
        path = new Vector3[] {
            currentPosition,
            new Vector3(currentPosition.x + attackDirection.y, currentPosition.y + attackDirection.x, currentPosition.z),
            new Vector3(currentPosition.x + attackDirection.x, currentPosition.y + attackDirection.y, currentPosition.z),
            new Vector3(currentPosition.x + attackDirection.y, currentPosition.y - attackDirection.x, currentPosition.z)
        };
        else
            path = new Vector3[] {
            currentPosition,
            new Vector3(currentPosition.x + attackDirection.y, currentPosition.y + 1.5f*attackDirection.x, currentPosition.z),
            new Vector3(currentPosition.x + attackDirection.x, currentPosition.y + 1.5f*attackDirection.y, currentPosition.z),
            new Vector3(currentPosition.x - attackDirection.y, currentPosition.y - 1.5f*attackDirection.x, currentPosition.z)
        };

        iTween.RotateBy(gameObject, iTween.Hash(
            "z", Random.Range(0.2f,0.7f),
            "time", Random.Range(0.2f, 0.7f)));

        iTween.MoveTo(gameObject, iTween.Hash(
            "oncomplete", "SpawnCrack",
            "oncompletetarget", gameObject,
            "path", path,
            "easetype", iTween.EaseType.easeInCubic,
            "time", Random.Range(0.4f, 0.6f)
            ));
    }

}
