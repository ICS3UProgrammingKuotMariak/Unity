using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public PlayerHealth playerHealth;
    public HealthBar healthBar;
    public float damageTaken;
    public GameObject portal;


    public float health;
    int enemiesLeft = 0;
    bool killedAllEnemies = false;

    // Use this for initialization
    void Start () {
        enemiesLeft = 3;
        health = 1f;
        damageTaken = 0.1f;
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
                health = health - damageTaken;
                Debug.Log(health);
                healthBar.SetSize(health);
                
        }

        }

    }
}
