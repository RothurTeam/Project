using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationOnPlayer : MonoBehaviour
{
    protected Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (player.position.x > transform.position.x)
        {
            Quaternion rot = transform.rotation;
            rot.y = 0;
            rot.x = 0;
            transform.rotation = rot;
        }
        else if (player.position.x < transform.position.x)
        {
            Quaternion rot = transform.rotation;
            rot.y = 180;
            rot.x = 0;
            transform.rotation = rot;
        }
    }
}
