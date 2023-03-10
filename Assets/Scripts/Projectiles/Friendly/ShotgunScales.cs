using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScales : Bullet
{
    void Start()
    {
        speed = 9.7f;
        damage = 0.185f;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void Destroy()
    {
        DestroyObject(gameObject);
    }
    void Update()
    {
        timeDestroy += Time.deltaTime;
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (timeDestroy > 0.4f)
        {
            Destroy();
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Untagged")
        {
            Destroy(gameObject);
        }
        if (hitInfo.tag == "Enemys")
        {
            //Enemy.hpEnemy -= damage;
            hitInfo.GetComponent<Enemy>().OnHit();
            Destroy(gameObject);
        }
    }
}
