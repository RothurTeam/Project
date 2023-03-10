using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 6f;

    public float timeDestroy;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = transform.right * speed;
    }

    private void Destroy()
    {
        DestroyObject(gameObject);
    }
    void Update()
    {
        //RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatItSolid);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Untagged")
        {
            Destroy(gameObject);
        }
        if (hitInfo.tag == "Player")
        {
            hitInfo.GetComponent<HealthPlayer>().OnHitPlayer();
            Destroy(gameObject);
        }
    }
}
