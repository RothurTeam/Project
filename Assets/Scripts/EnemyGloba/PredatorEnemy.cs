using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorEnemy : Enemy
{
    public float force = 5f;
    private Vector2 movement;

    private void Start()
    {
        //hpEnemy = 1f;
    }

    private void Update()
    {
        /*if (Vector3.Distance(transform.position, player.transform.position) < 3f) //3 - радиус атаки
        {
            player.GetComponent<HealthPlayer>().OnHitPlayer();
        }*/
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
