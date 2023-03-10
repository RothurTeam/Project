using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spawnEnemy;
    [SerializeField]
    private GameObject[] spawnPoint;

    public int numEnemy;
    public int EnemyRand;
    public int RandomPoint;
    public int RandomPoint1;
    [SerializeField] public bool runOnce = false;

    void Start()
    {
        runOnce = true;
    }

    void Update()
    {
        if (runOnce == true)
        {
            RandomPoint = Random.Range(0, spawnPoint.Length);
            RandomPoint1 = Random.Range(0, spawnPoint.Length);
            for (int i = 0; i < 1; i++)
            {
                Instantiate(spawnEnemy[RandomPoint1], spawnPoint[RandomPoint].transform.position, Quaternion.identity);
            }
            runOnce = false;
            DestroyObject(gameObject);
        }
    }
}
