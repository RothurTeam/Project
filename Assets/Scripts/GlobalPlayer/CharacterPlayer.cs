using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlayer : MonoBehaviour
{
    [SerializeField] GameObject empty;
    [SerializeField] GameObject lazygun;
    [SerializeField] GameObject rifle;

    public enum Players { Empty, Lazygun, Rifle }
    Players weapon;

    [SerializeField] int player = 1;
    //int count = 1;

    public void ChangeWeapon(int weapons)
    {
        player = weapons;
    }

    public int GetWeapon()
    {
        return player;
    }
    void Start()
    {
        //GetComponent<PlayerLook>().enabled = true;
        switch (player)
        {
            case 1:
                ChooseWeapon(Players.Empty);
                break;
            case 2:
                ChooseWeapon(Players.Lazygun);
                break;
            case 3:
                ChooseWeapon(Players.Rifle);
                break;
            default:
                print("Для этого уровня не подготовлено оружие");
                break;
        }
    }

    void Update()
    {
        switch (player)
        {
            case 1:
                ChooseWeapon(Players.Empty);
                break;
            case 2:
                ChooseWeapon(Players.Lazygun);
                break;
            case 3:
                ChooseWeapon(Players.Rifle);
                break;
            default:
                print("Для этого уровня не подготовлено оружие");
                break;
        }
        //ChooseWeapon(Weapon.Dummy);
        //ChooseWeapon(Weapon.Lazygun);
    }

    public void ChooseWeapon(Players weapon)
    {
        this.weapon = weapon;
        switch (weapon)
        {
            case Players.Empty:
                empty.SetActive(true);
                lazygun.SetActive(false);
                rifle.SetActive(false);
                break;
            case Players.Lazygun:
                empty.SetActive(false);
                lazygun.SetActive(true);
                rifle.SetActive(false);
                break;
            case Players.Rifle:
                empty.SetActive(false);
                lazygun.SetActive(false);
                rifle.SetActive(true);
                break;
            default:
                print("Такого оружия у вас нет");
                break;
        }
    }
}
