using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttack : MonoBehaviour {

    public int damage;
    public float attackDelay = 100;
    float lastAttacked = -9999;

    Animator anim;
    GameObject player;
    HealthScript playerHealth;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<HealthScript>();
    }

    private void Update()
    {
        if (SlimeAi.PlayerFound == true)
        {
            Attack();
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SlimeAi.PlayerFound = true;
            
        }

    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SlimeAi.PlayerFound = false;
            SlimeAi.IsAttacking = false;
            Debug.Log("Player is not damaged");
        }
    }

    public void Attack()
    {
       if (Time.time > lastAttacked + attackDelay)
        {
            SlimeAi.IsAttacking = true;
            playerHealth.TakeDamage(damage);
            Debug.Log("Player will be damaged " + damage);
        }
        lastAttacked = Time.time;
    }

}
