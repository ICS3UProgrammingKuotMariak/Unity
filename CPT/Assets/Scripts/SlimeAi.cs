﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SlimeAi : MonoBehaviour {

    public float speed;
    public float Followspeed = 1f;
    public float distance = 3f;
    public int damage;
    public float direction = -1;

    public Animator animator;
    public Transform groundDetection;
    public Transform playerDetection;
    public RaycastHit2D groundInfo;

    public static bool PlayerFound = false;

    private Rigidbody2D rb;
    private bool movingLeft = true;
    private bool m_FacingRight;
    
    private Transform targetPos;

    public static bool IsAttacking = false;
    public static bool PlayerIsDamaged = false;

    public Vector2 rayDirection = Vector2.left;



    public void Start()
    {
        targetPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        
 
    }

    public void FixedUpdate()
    {
        if (PlayerFound == false)
        {
            speed = 0.5f;
            rb.velocity = new Vector2(direction * speed, rb.velocity.y);

            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
            if (groundInfo.collider == false || groundInfo.collider.tag == "Slope")
            {
                if (movingLeft == true)
                {
                    Flip();
                    direction = 1;
                    rayDirection = Vector2.right;
                    movingLeft = false;
                }
                else
                {
                    Flip();
                    direction = -1;
                    rayDirection = Vector2.left;
                    movingLeft = true;
                }

            }

        }
        else if (PlayerFound == true)
        {
            speed = 0f;
            rb.velocity = Vector2.zero;
        }

        animator.SetFloat("Speed", speed);
        
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
