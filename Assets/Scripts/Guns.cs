using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected GameObject bullet2;
    [SerializeField] protected Transform bulletPosition;

    protected bool auto = false;
    protected float cooldown = 0;
    [SerializeField] float xy0;

    private float timer = 0;

    public void Shoot()
    {
        if (Input.GetMouseButtonDown(0) || auto)
        {
            if (timer > cooldown)
            {
                OnShoot();
                timer = 0;
            } 
        }
    }

    protected virtual void OnShoot()
    {

    }

    private void Start()
    {
        timer = cooldown;
    }
    private void Update()
    {
        timer += Time.deltaTime;
    }
}
