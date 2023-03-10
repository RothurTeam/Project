using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerBullet : EnemyBullets
{
    void Start()
    {
        speed = 14f;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }
    void Update()
    {
        timeDestroy += Time.deltaTime;
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (timeDestroy > 1.26f)
        {
            Destroy(gameObject);
        }
    }
}
