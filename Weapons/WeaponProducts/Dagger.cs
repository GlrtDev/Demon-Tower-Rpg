using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MeleeWeapon
{
    public Dagger(int rarity, int level)
    {
        base.Instantiate(WeaponType.Dagger);
        int Number = (level / 10) % 10;
        itemStats["Type"] = WeaponType.Dagger;
        itemStats["WeaponNumber"] = Number;
        itemStats["Rarity"] = rarity;
        itemStats["Name"] = WeaponNames[(int)WeaponType.Dagger, Number * 2 + rarity];
        itemStats["Damage"] = 3 + ((0.35f * rarity) * level) + (level * 1);
        itemStats["AttackRate"] = 0;
        itemStats["SpritePath"] = "Sprites/Weapons/Daggers/dagger" + Number + "-" + rarity + "-level" + itemStats["WeaponLevel"];
        itemStats["IconPath"] = ""; // TO DO icons
        itemStats["trailStartColXY"] = new Vector2Int(27, 85);
        itemStats["trailEndColXY"] = new Vector2Int(27, 70);
        itemStats["trailWidth"] = 0.1f + (int)itemStats["WeaponLevel"] * 0.02f; // wpn level
        itemStats["PrefabPath"] = "Prefabs/DaggerBase";
        Initialize();
    }

    public override void Attack(Vector3 currentPosition, Vector2 attackDirection)
    {
        Initialize();
        //gameObject.transform.position = currentPosition;
        //Vector3[] path = new Vector3[3];
        //float animateTime = Random.Range(0.2f, 0.3f);
        //float randomness = Random.Range(-1, 1);

        
        Debug.Log(Vector2.SignedAngle(new Vector2(0, 1), attackDirection));

        attackDirection *= 5f;
        //if (Mathf.Abs(attackDirection.x) > Mathf.Abs(attackDirection.y))
        //path = new Vector3[] {//currentPosition,
        //    new Vector3(currentPosition.x + randomness, currentPosition.y + randomness, currentPosition.z),
        //    new Vector3(currentPosition.x + attackDirection.x + randomness, currentPosition.y + attackDirection.y + randomness, currentPosition.z)
        //};

        //iTween.RotateTo(gameObject, iTween.Hash(
        //   // "z", Vector2.SignedAngle(new Vector2(0, 1), attackDirection),
        //    "z", Vector2.SignedAngle(new Vector2(0, 1), attackDirection + new Vector2(randomness, randomness)),
        //    "time", animateTime,
        //    "easetype", iTween.EaseType.spring));

        //iTween.MoveTo(gameObject, iTween.Hash(
        //   // "oncomplete", "SpawnCrack",
        //   // "oncompletetarget", gameObject,
        //    "path", path,
        //    "easetype", iTween.EaseType.spring,
        //    "time", animateTime
        //    ));
        
        iTween.RotateUpdate(gameObject, new Vector3(0, 0, Vector2.SignedAngle(new Vector2(0, 1), attackDirection)), 0.5f);
        iTween.MoveUpdate(gameObject, iTween.Hash(
            // "oncomplete", "SpawnCrack",
            // "oncompletetarget", gameObject,
            "x", currentPosition.x + attackDirection.x,
            "y", currentPosition.y + attackDirection.y,
            "time", 1.1f
            ));

        //iTween.RotateUpdate(gameObject, iTween.Hash(
        //    "z", Vector2.SignedAngle(new Vector2(0, 1), attackDirection),
        //    "time", 0.5f));

        
    }
}
