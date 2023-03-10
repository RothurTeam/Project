using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] public float hpEnemy;
    [SerializeField] public float powerForce = 17f;
    public float direction = 1f;
    public float speed = 3f;
    public static int enemyDamage = 1;
    protected Transform player;
    protected Transform portal;
    protected Transform healthPlayer;

    public void TakeDamage(int damaged)
    {
        hpEnemy -= damaged;
    }
    private void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, player.position, speed);
        if (Vector2.Distance(transform.position, player.transform.position) < 0.644f) //3 - радиус атаки
        {
            player.GetComponent<HealthPlayer>().OnHitPlayer();
        }

        //float move = Input.GetAxis("Horizontal");
        /*if (transform.position.x > player.transform.position.x)
        {
            Quaternion rot = transform.rotation;
            rot.y = 0;
            rot.x = 0;
            transform.rotation = rot;
        }

        if (transform.position.x < player.transform.position.x)
        {
            Quaternion rot = transform.rotation;
            rot.y = 180;
            rot.x = 0;
            transform.rotation = rot;
        }*/
        Move();
        CheckPlayerRot();
        if (hpEnemy > 0)
        {
            //hpEnemy -= Bullet.damage;
        }
        if (hpEnemy <= 0)
        {
            //portal.GetComponent<PortalsSystems>().enemies.Count -= 1;
            Destroy(gameObject);
        }
    }

    public virtual void CheckPlayerRot()
    {
        
    }
    public virtual void Move()
    {

    }
    public virtual void Attack()
    {

    }
    public void OnHit()
    {
        if (hpEnemy > 0)
        {
            hpEnemy -= Bullet.damage;
        }
        if (hpEnemy <= 0)
        {
            Destroy(gameObject);

        }
    }

    void Start()
    {
        //hpEnemy = 3f;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "BulletFriendly")
        {
            //hitInfo.GetComponent<Enemy>().OnHit();
            //OnHit();
            if (hpEnemy > 0)
            {
                //hpEnemy -= Bullet.damage;
            }
            if (hpEnemy <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
