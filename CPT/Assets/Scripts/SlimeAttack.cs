using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttack : MonoBehaviour {

    public Animator animator;
    public static bool IsAttacking = false;

    private Collider2D attackCheck;
    public Collider2D player;

    private void Start()
    {
        
        animator = GetComponent<Animator>();
        attackCheck = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (attackCheck == GameObject.FindGameObjectWithTag("Player"))
        {
            IsAttacking = true;
        }
    }
}
