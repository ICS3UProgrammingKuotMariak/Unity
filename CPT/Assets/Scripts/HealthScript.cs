using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

    public Collider2D Enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent <Collider2D>();

    

    public class PlayerHealth
    {
        public float Health = 50f;
    }
    public PlayerHealth playerHealth = new PlayerHealth();

    


}
