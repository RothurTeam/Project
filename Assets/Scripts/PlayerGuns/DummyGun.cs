using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DummyGun : Guns
{
    void Start()
    {
        cooldown = 0.5f;
        auto = true;
    }

    protected override void OnShoot()
    {
        Instantiate(bullet, bulletPosition.position, transform.rotation);
    }
}

