using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletP1 : Bullet
{
    public override void SetDamage()
    {
        damage = FindObjectOfType<GameSettings>().bulletDamage[1];
    }
}
