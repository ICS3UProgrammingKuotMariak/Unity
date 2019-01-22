using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public PlayerHealth playerHealth;

    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    int enemiesLeft = 0;
    public GameObject portal;
    public GameObject Enemy;
    public GameObject DeathScreen;
    public GameObject player;
    bool killedAllEnemies = false;
    bool stageIsCleared = false;
    public bool gameOver;
    public Text EnemiesKilled;


    public AudioSource music;
    public AudioClip death;
    public AudioClip stageClear;

    // Use this for initialization
    void Start () {
        enemiesLeft = 4;
        Spawn();
        music = gameObject.GetComponent<AudioSource>();
        gameOver = false;


    }
	
	// Update is called once per frame
	void Update () {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemies.Length;


        if (gameOver == true)
        {
            DeathScreen.SetActive(true);
        }
    }

    public void GameOver ()
    {
        gameOver = true;
        
    }

    void Spawn ()
    {

        Instantiate(Enemy, spawnPoints[0].position, spawnPoints[0].rotation);
        Instantiate(Enemy, spawnPoints[1].position, spawnPoints[1].rotation);
        Instantiate(Enemy, spawnPoints[2].position, spawnPoints[2].rotation);
        Instantiate(Enemy, spawnPoints[3].position, spawnPoints[3].rotation);

    }
}
