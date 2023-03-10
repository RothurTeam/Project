using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : Enemy
{
    public float time;
    public float shootTimer;
    public int PointPosition;
    public bool runPoint = true;
    public Transform[] pointGunner;
    public GameObject bulletEnemy;
    public Transform ShootPosition;
    private void Start()
    {
        hpEnemy = 0.5f;
        speed = 5f;
    }

    void Update()
    {
        Move();
    }

    public override void Move() 
    {

        time += Time.deltaTime;
        shootTimer += Time.deltaTime;
        if (time > 0.8f)
        {
            time = 0;
            runPoint = true;
        }
        if (shootTimer > 1f)
        {
            Instantiate(bulletEnemy, ShootPosition.position, ShootPosition.rotation);
            shootTimer = 0;
        }
        if (time > 0.3 && time < 0.5)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointGunner[PointPosition].transform.position, speed * Time.deltaTime);
        }
        if (runPoint)
        {
            PointPosition = Random.Range(0, pointGunner.Length);
            runPoint = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Player")
        {
            //HealthPlayer.health -= 1;
            //gameObject.GetComponent<Rigidbody2D>().AddForceAtPosition(Vector2.up * 100, Vector2.right * 10);
            //gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * direction * powerForce, ForceMode2D.Impulse);

        }

        if (hitInfo.tag == "Enemys")
        {
            //GetComponent<Rigidbody2D>().AddForce(impulse, ForceMode2D.Impulse);
        }
    }
}
