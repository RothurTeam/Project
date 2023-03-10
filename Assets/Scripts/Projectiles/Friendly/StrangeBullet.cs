using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrangeBullet : Bullet
{
    Vector3 direction;
    void Start()
    {
        speed = 15f;
        damage = 0.3f;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    public void setDirection(Vector3 dir)
    {
        direction = dir;
    }

    private void Destroy()
    {
        DestroyObject(gameObject);
    }
    void Update()
    {
        timeDestroy += Time.deltaTime;
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (timeDestroy > 1.65f)
        {
            Destroy();
        }
        if (timeDestroy > 0.1f)
        {
            //transform.position += direction * speed  * Time.deltaTime;
        }
        rb.velocity = transform.right * speed * Time.deltaTime * 2;
        speed += 0.1f;
    }

    void FixedUpdate()
    {
            transform.position += direction / speed * Time.deltaTime;
            speed *= 0.9f;
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
