using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttack : MonoBehaviour {

    public Animator animator;
    public bool IsAttacking = false;

    private Collider2D attackCheck;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    
}
