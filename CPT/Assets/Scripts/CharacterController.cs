using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CharacterController : MonoBehaviour {


    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;


    public bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 650f;

    Animator animator;


	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
            animator.SetBool("Ground", grounded);

        animator.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);

	}

    void Update()
    {
        if (grounded && Input.GetButtonDown("Jump"))
        {
            animator.SetBool("Ground", false);
            m_Rigidbody2D.AddForce(new Vector2(0, jumpForce));
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
