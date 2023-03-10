using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthPlayer : MonoBehaviour
{
    public GameObject HP1, HP2, HP3;
    public static int health;
    [SerializeField] public float cooldownHPdamage;
    void Start()
    {
        HP1.SetActive(true);
        HP2.SetActive(true);
        health = 3;
        cooldownHPdamage = 2.2f;
    }

    public void OnHitPlayer()
    {
        if (health > 0 && cooldownHPdamage > 2.2f)
        {
            health -= 1;
            cooldownHPdamage = 0;
        }
    }

    public void PlayerTakeDamage(int damage)
    {
        health -= damage;
    }

    void Update()
    {
        cooldownHPdamage += Time.deltaTime;
        if(health <= 0)
        {
            SceneManager.LoadScene(0);
        }
        switch (health)
        {
            case 3:
                HP1.SetActive(true);
                HP2.SetActive(true);
                HP3.SetActive(true);
                break;
            case 2:
                HP1.SetActive(true);
                HP2.SetActive(true);
                HP3.SetActive(false);
                break;
            case 1:
                HP1.SetActive(true);
                HP2.SetActive(false);
                HP3.SetActive(false);
                break;
            case 0:
                HP1.SetActive(false);
                HP2.SetActive(false);
                HP3.SetActive(false);
                break;
        }
    }
}
