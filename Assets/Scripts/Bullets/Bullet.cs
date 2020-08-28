using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    
    protected int damage;
    protected BulletPoolObject pool;

    public void SetVelocity(Vector3 velocity)
    {
        rb.velocity = velocity;
    }

    public int GetDamage()
    {
        return damage;
    }
    public abstract void SetDamage();

    public void SetPool(BulletPoolObject pool)
    {
        this.pool = pool;
    }

    public void ReturnToPool()
    {
        pool.ReturnToPool(this);
    }

}
