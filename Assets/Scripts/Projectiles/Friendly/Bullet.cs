using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Rigidbody2D rb;
    public float speed;
    public static float damage;
    public float penetrateCooldown;
    //public static float distance;
    protected float timeDestroy;
    public int penetrate;
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        //rb.velocity = transform.right * speed;
    }

    private void Destroy()
    {
        DestroyObject(gameObject);
    }

    public virtual void PenetrateWork()
    {
        penetrateCooldown += Time.deltaTime;
        //if (penetrateCooldown)
    }

    void Update()
    {
        //RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatItSolid);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.tag == "Untagged")
        {
            Destroy(gameObject);
        }
        if (hitInfo.tag == "Enemys")
        {
            //hitInfo.GetComponent<Enemy>().OnHit();
            //Enemy.hpEnemy -= damage;
            Destroy(gameObject);
           // Destroy();
        }
    }
}
