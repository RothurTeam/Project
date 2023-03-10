using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] GameObject player;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    /*public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }*/

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
