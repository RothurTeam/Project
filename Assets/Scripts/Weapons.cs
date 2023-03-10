using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] GameObject dummy;
    [SerializeField] GameObject lazygun;
    [SerializeField] GameObject rifle;
    [SerializeField] GameObject shotgun;

    public enum Weapon { Dummy, Lazygun, Rifle, Shotgun }
    Weapon weapon;

    [SerializeField] int level = 1;
    //int count = 1;

    public void ChangeWeapon(int weapons)
    {
        level = weapons;
    }

    public int GetWeapon()
    {
        return level;
    }
    void Start()
    {
        //GetComponent<PlayerLook>().enabled = true;
        switch (level)
        {
            case 1:
                ChooseWeapon(Weapon.Dummy);
                break;
            case 2:
                ChooseWeapon(Weapon.Lazygun);
                break;
            case 3:
                ChooseWeapon(Weapon.Rifle);
                break;
            case 4:
                ChooseWeapon(Weapon.Shotgun);
                break;
            default:
                print("Для этого уровня не подготовлено оружие");
                break;
        }
    }

    void Update()
    {
        switch (level)
        {
            case 1:
                ChooseWeapon(Weapon.Dummy);
                break;
            case 2:
                ChooseWeapon(Weapon.Lazygun);
                break;
            case 3:
                ChooseWeapon(Weapon.Rifle);
                break;
            case 4:
                ChooseWeapon(Weapon.Shotgun);
                break;
            default:
                print("Для этого уровня не подготовлено оружие");
                break;
        }
        //ChooseWeapon(Weapon.Dummy);
        //ChooseWeapon(Weapon.Lazygun);
        if (Input.GetMouseButton(0))
        {
            switch (weapon)
            {
                case Weapon.Dummy:
                    dummy.GetComponent<Guns>().Shoot();
                    break;
                case Weapon.Lazygun:
                    lazygun.GetComponent<Guns>().Shoot();
                    break;
                case Weapon.Rifle:
                    rifle.GetComponent<Guns>().Shoot();
                    break;
                case Weapon.Shotgun:
                    shotgun.GetComponent<Guns>().Shoot();
                    break;
            }
        }
    }

    public void ChooseWeapon(Weapon weapon)
    {
        this.weapon = weapon;
        switch (weapon)
        {
            case Weapon.Dummy:
                dummy.SetActive(true);
                lazygun.SetActive(false);
                rifle.SetActive(false);
                shotgun.SetActive(false);
                break;
            case Weapon.Lazygun:
                dummy.SetActive(false);
                lazygun.SetActive(true);
                rifle.SetActive(false);
                shotgun.SetActive(false);
                break;
            case Weapon.Rifle:
                dummy.SetActive(false);
                lazygun.SetActive(false);
                rifle.SetActive(true);
                shotgun.SetActive(false);
                break;
            case Weapon.Shotgun:
                dummy.SetActive(false);
                lazygun.SetActive(false);
                rifle.SetActive(false);
                shotgun.SetActive(true);
                break;
            default:
                print("Такого оружия у вас нет");
                break;
        }
    }
}


