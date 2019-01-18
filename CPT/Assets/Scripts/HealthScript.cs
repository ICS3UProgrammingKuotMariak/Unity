using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

    public Collider2D Enemy;
    public static bool damaged;
    public static Animator anim;

    

    public int Health;

    void Awake()
    {
        anim = GetComponent<Animator>();
        Enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Collider2D>();
    }

    void Update()
    {
        if (damaged)
        {
            anim.SetBool("IsHurt", true);
        }
        else
        {
            anim.SetBool("IsHurt", false);
        }

        damaged = false;

    }

    public void TakeDamage(int damage)
    {
        damaged = true;
        Health = Health - damage;

        if (Health <= 0)
        {
            Death();
        }
        Debug.Log("Damage Taken" + Health);
    }

    public void Death ()
    {
        anim.SetTrigger("Death");
        Destroy(gameObject, 0.7f);
    }
   
}
