using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangBullet : Bullet
{
    Vector3 direction;
    float RotateSpin = 0f;
    public new Rigidbody2D rb;

    void Start()
    {
        speed = 15.5f;
        damage = 0.38f;
        penetrate = 3;
        penetrateCooldown = 0.105f;
        //rb = GetComponent<Rigidbody2D>();
        //rb.velocity = transform.right * speed;
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
        //transform.Rotate(new Vector2(spin, spin));
        //transform.Rotate(new Vector3(0, 0, spin));

        //float angle = transform.eulerAngles.z;
        //transform.Rotate(0, 0, RotateSpin * 1f * Time.deltaTime);
        timeDestroy += Time.deltaTime;
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (timeDestroy > 1.375f)
        {
            Destroy();
        }
        PenetrateWork();
        //rb.rotation = RotateSpin;
        //RotateSpin += 1;
        //rb.AddTorque(10 * Time.deltaTime);

    }

    void FixedUpdate()
    {
        if (timeDestroy > 0.495f)
        {
            transform.position -= direction * speed * Time.deltaTime;
            speed -= 1f;
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
            if (penetrateCooldown > 0.105f) { 
                //Enemy.hpEnemy -= GetComponent<Enemy>().TakeDamage(-damage);
                hitInfo.GetComponent<Enemy>().OnHit();
                penetrateCooldown = 0;
                penetrate -= 1;
                //Destroy(gameObject);
                // Destroy();
            }
            if (penetrate == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
