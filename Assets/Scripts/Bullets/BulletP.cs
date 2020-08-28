using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletP : Bullet
{
    public override void SetDamage()
    {
        damage = FindObjectOfType<GameSettings>().bulletDamage[0];
    }

}
