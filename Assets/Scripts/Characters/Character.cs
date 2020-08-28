using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public int health;
    public Weapon weapon;

    protected Transform target;    
    protected CharactersManager cm;
    protected Coroutine shootCoroutine;

    public virtual void Start()
    {
        cm = FindObjectOfType<CharactersManager>();
    }

    public void Update()
    {
        transform.LookAt(target);
    }

    IEnumerator Shooting()
    {
        while (target != null) {
            Vector3 direction = target.position - transform.position;
            weapon.Shoot(direction);

            yield return new WaitForSeconds(weapon.shootDelay);
        }
    }

    public void SetTarget(Transform target)
    {
        this.target = target;

        if (shootCoroutine != null) {
            StopCoroutine(shootCoroutine);
        }
        shootCoroutine = StartCoroutine(Shooting());
    }

    public void SetDamage(int damage)
    {
        health -= damage;

        if (health <= 0) {
            Death();
        }
    }

    abstract public void Death();

}
