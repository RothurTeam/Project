using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nowEnemyCheck : MonoBehaviour
{
    public int nowTheEnemies;
    private Transform enemy;
    //private Transform portals;
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemys").GetComponent<Transform>();
    }

    void Update()
    {
        if (enemy.childCount == 0)
        {
            transform.GetComponent<PortalsSystems>().spawned = false;
        }
    }
}
