using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    Bullet bullet;

    private void Start()
    {
        bullet = GetComponent<Bullet>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Character") {
            collision.gameObject.GetComponent<Character>().SetDamage(bullet.GetDamage());
        }

        bullet.ReturnToPool();
    }


}
