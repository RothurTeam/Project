using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalsSystems : MonoBehaviour
{
    [SerializeField] bool newRoom = true;
    [SerializeField] private Transform[] spawnPlayer;
    private Transform spawnPortal;
    private Transform player;
    public float RotateSpeed;
    protected Transform spawnEnemy;

    public int RandomPoint;
    public int wave;

    //int qty = GameObject.FindGameObjectWithTag("Enemys").Length;
    public GameObject[] enemys;

    [Header("Enemys")]
    public GameObject[] enemyTypes;
    public Transform[] enemySpawners;
    public GameObject BigEnemyTypes;
    public Transform BigEnemySpawners;

    [HideInInspector] public List<GameObject> enemies;

    private RoomsVariant variants;
    public bool spawned;
    private bool portalActive;

    private void FixedUpdate()
    {
        float angle = transform.eulerAngles.z;
       
        //transform.Rotate(0, 0, RotateSpeed * 1f * Time.deltaTime);
    }

    private void Start()
    {
        spawned = false;
        enemys = GameObject.FindGameObjectsWithTag("Enemys");
        //variants = GameObject.FindGameObjectsWithTag("Spawners").GetComponent<RoomsVariant>();
        spawnEnemy = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<Transform>();
    }

    void Update()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemys");
        if (enemies.Count == 1)
        {
            //spawned = false;
        }
        StartCoroutine(CheckEnemies());
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Player" && !spawned)
        {
            if (enemys.Length <= 0) {
                wave += 1;
                hitInfo.GetComponent<PlayerMove>().Teleport();
                if (wave >= 3)
                {
                    BigGuys();
                }
                foreach (Transform spawner in enemySpawners)
                {
                    int rand = Random.Range(0, 11);
                    if (rand < 9 && wave < 3)
                    {
                        GameObject enemyType = enemyTypes[Random.Range(0, enemyTypes.Length)];
                        GameObject enemy = Instantiate(enemyType, spawner.position, Quaternion.identity) as GameObject;
                        enemy.transform.parent = transform;
                        enemies.Add(enemy);
                    }
                    if (wave >= 3)
                    {
                        GameObject enemyType = enemyTypes[Random.Range(0, enemyTypes.Length)];
                        GameObject enemy = Instantiate(enemyType, spawner.position, Quaternion.identity) as GameObject;
                        enemy.transform.parent = transform;
                        enemies.Add(enemy);
                    }
                    /*if (Random.Range(0, 11) < 9 && wave >= 3)
                    {
                        GameObject enemyType = enemyTypes[Random.Range(0, enemyTypes.Length)];
                        GameObject enemy = Instantiate(BigEnemyTypes, BigEnemySpawners[Random.Range(0, 2)].position, Quaternion.identity) as GameObject;
                        enemy.transform.parent = transform;
                        enemies.Add(enemy);
                    }*/
                    
                }
            }
            //StartCoroutine(CheckEnemies());

        }
    }

    public virtual void BigGuys()
    {
        int rand = Random.Range(0, 11);
        if (rand < 9 && wave >= 3)
        {
            GameObject enemy2 = Instantiate(BigEnemyTypes, BigEnemySpawners.position, Quaternion.identity) as GameObject;
            enemy2.transform.parent = transform;
            enemies.Add(enemy2);
        }
    }

    IEnumerator CheckEnemies()
    {
        yield return new WaitForSecondsRealtime(1f);
        yield return new WaitUntil(() => enemies.Count == 0);
        spawned = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //RandomPoint = Random.Range(0, spawnPlayer.Length);
            //collision.gameObject.transform.position = spawnPlayer[RandomPoint].gameObject.transform.position;
            collision.transform.position = spawnPortal.transform.position;

        }
    }
}
