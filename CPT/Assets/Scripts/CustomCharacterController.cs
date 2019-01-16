using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CustomCharacterController : MonoBehaviour {


    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.


    public bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 650f;
    public float maxSpeed = 10f;


    public bool crouch = false;
    bool isCrouching;
    public RaycastHit2D ceilingInfo;
    public float distance = 2f;
    public Transform ceilingCheck;


    public static Vector2 controller;

    Animator animator;


	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        controller = m_Rigidbody2D.velocity;

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
            animator.SetBool("Ground", grounded);

        animator.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);

       float move = Input.GetAxis("Horizontal");

       float slide  = Input.GetAxisRaw("Vertical") * maxSpeed;

        animator.SetFloat("Speed", Mathf.Abs(move));

        m_Rigidbody2D.velocity = new Vector2(move * maxSpeed, m_Rigidbody2D.velocity.y);

        if (move > 0 && !m_FacingRight)
            Flip();
        else if (move < 0 && m_FacingRight)
            Flip();

    }

    void Update()
    {
        RaycastHit2D ceilingInfo = Physics2D.Raycast(ceilingCheck.position, Vector2.up, distance);

        if (grounded && Input.GetButtonDown("Jump"))
        {
            animator.SetBool("Ground", false);
            m_Rigidbody2D.AddForce(new Vector2(0, jumpForce));
        }

        if (Input.GetButton("Crouch"))
        {
            crouch = true;
        }
        else
        {
            if (ceilingInfo.collider == true)
            {
                crouch = true;

            }
            else if (ceilingInfo.collider == false)
            {
                crouch = false;

            }

        }

        animator.SetBool("IsCrouching", crouch);

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
