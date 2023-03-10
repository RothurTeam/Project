using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLoot : MonoBehaviour
{
    [SerializeField] int number;
    void Start()
    {
        //GetComponent<Weapons>().level = 2;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<Weapons>().ChangeWeapon(number);
            Destroy(gameObject);
        }
        //Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
