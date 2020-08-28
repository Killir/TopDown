using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform bulletStartPoint;
    public BulletPoolObject pool;
    public float shootDelay = 1f;
    public float bulletSpeed = 10f;

    public void Shoot(Vector3 direction)
    {
        Bullet nextBullet = pool.GetBullet();
        nextBullet.transform.position = bulletStartPoint.transform.position;
        nextBullet.SetVelocity(direction.normalized * bulletSpeed);
    }



}
