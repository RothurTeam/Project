using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunGun : Guns
{
    void Start()
    {
        cooldown = 0.725f;
        auto = true;
    }

    protected override void OnShoot()
    {
        for (int i = 0; i < 3 + Random.Range(0, 2); i++)
        {
            Vector3 Angle = bulletPosition.eulerAngles;
            Angle.z += Random.Range(-17, 17);
            Instantiate(bullet, bulletPosition.position, Quaternion.Euler(Angle));
        }
    }
}
