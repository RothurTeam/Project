using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangoGun : Guns
{
    void Start()
    {
        cooldown = 0.725f;
        auto = true;
    }

    protected override void OnShoot()
    {
        Instantiate(bullet, bulletPosition.position, transform.rotation);
    }
}
