using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public float speed;

    Rigidbody rb;
    InputManager im;

    public override void Start()
    {
        rb = GetComponent<Rigidbody>();
        im = FindObjectOfType<InputManager>();

        base.Start();
    }

    void FixedUpdate()
    {
        Vector2 direction = im.GetDirection();
        rb.velocity = new Vector3(direction.x, rb.velocity.y, direction.y) * speed;
    }

    public override void Death()
    {
        cm.OnPlayerDeath();
    }

}
