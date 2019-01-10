using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SlimeAi : MonoBehaviour {

    public float speed;
    public float Followspeed;
    public float distance;
    public int damage;
    public float direction = -1;

    public Animator animator;
    public Transform groundDetection;
    public Transform playerDetection;
    public RaycastHit2D groundInfo;

    public bool PlayerFound;

    private Rigidbody2D rb;
    private bool movingLeft = true;
    private bool m_FacingRight;
    private Collider2D target;
    private Transform targetPos;

    public bool IsAttacking = false;

    private Collider2D attackCheck;


    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        targetPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if ((GameObject.Find("Player") != null))
        {
            rb.velocity = new Vector2(direction * speed, rb.velocity.y);

            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
            if (groundInfo.collider == false)
            {
                if (movingLeft == true)
                {
                    Flip();
                    direction = 1;
                    movingLeft = false;
                }
                else
                {
                    Flip();
                    direction = -1;
                    movingLeft = true;
                     
                }

                
            }
            else
            {
                FindPlayer();
                FollowPlayer();
            }
        }
    }

    public void FixedUpdate()
    {
        animator.SetFloat("Speed", speed);
    }


    public void FindPlayer ()
    {
        RaycastHit2D playerDetect = Physics2D.Raycast(playerDetection.position, Vector2.left, distance);
        
            if (playerDetect.collider == target)
            {
                PlayerFound = true;
                
            }
            else
            {
                PlayerFound = false;
            }
        

    }

    public void FollowPlayer ()
    {
        if (PlayerFound == true)
        {
            rb.velocity = Vector2.MoveTowards(transform.position, targetPos.position, Followspeed * Time.deltaTime);
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (attackCheck == GameObject.FindGameObjectWithTag("Player"))
        {
            IsAttacking = true;
        }
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
