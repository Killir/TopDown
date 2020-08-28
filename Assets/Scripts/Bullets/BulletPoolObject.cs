using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolObject : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int startCount;

    Queue<Bullet> pool = new Queue<Bullet>();

    private void Start()
    {
        for (int i = 0; i < startCount; i++) {
            pool.Enqueue(CreateBullet());
        }
    }

    public Bullet GetBullet()
    {
        if (pool.Count == 0) {
            pool.Enqueue(CreateBullet());
        }
        Bullet bullet = pool.Dequeue();
        bullet.gameObject.SetActive(true);

        return bullet;
    }

    Bullet CreateBullet()
    {
        GameObject obj = Instantiate(bulletPrefab);
        obj.SetActive(false);

        Bullet bullet = obj.GetComponent<Bullet>();
        bullet.SetPool(this);
        bullet.SetDamage();

        return bullet;
    }

    public void ReturnToPool(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        pool.Enqueue(bullet);
    }
}
