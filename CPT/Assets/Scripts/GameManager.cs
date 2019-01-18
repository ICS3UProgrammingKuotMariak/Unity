using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public PlayerHealth playerHealth;
    public HealthBar healthBar;
    public float damageTaken;
    public float health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
