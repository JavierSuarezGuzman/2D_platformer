using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{

    private GameObject[] enemies;

    private bool levelUp;

    public string loadScene; //different names for different levels

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("EnemyTag");

        if (enemies.Length < 1 && !levelUp)
        {
            levelUp = true;
            //print ("Level has been passed");
            SceneManager.LoadScene(loadScene);  //next level is loaded
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name + 1); //loadup level 11 for some reason

            //PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1); //other method
            //SceneManager.LoadScene("Level" + PlayerPrefs.GetInt("Level"),1)); //follows
        }
    }
}
