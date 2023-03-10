using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazyGun : Guns
{
    int reload = 4;
    void Start()
    {
        cooldown = 0.82f;
        auto = true;
    }

    protected override void OnShoot()
    {
        //Instantiate(bullet, bulletPosition.position, transform.rotation);
        reload--;

        if (reload > 0)
        {
            Instantiate(bullet, bulletPosition.position, transform.rotation);
            cooldown = 0.1f;
        }
        else
        {
            Instantiate(bullet2, bulletPosition.position, transform.rotation);
            cooldown = 0.82f;
        }

        if (reload == -3)
        {
            reload = 4;
        }
    }
}
