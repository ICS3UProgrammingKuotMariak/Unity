using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public PlayerHealth playerHealth;

    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    int enemiesLeft = 0;
    public GameObject portal;
    public GameObject Enemy;
    bool killedAllEnemies = false;

    // Use this for initialization
    void Start () {
        enemiesLeft = 3;
        Spawn();
    }
	
	// Update is called once per frame
	void Update () {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemies.Length;


        if (enemiesLeft == 0)
        {
            portal.SetActive(true);
        }


        if (playerHealth.currentHealth > 0)
        {
            if (playerHealth.Hurt == true)
            {
                
                
            }

        }

    }

    void Spawn ()
    {
        Instantiate(Enemy, spawnPoints[].position);
    }
}
