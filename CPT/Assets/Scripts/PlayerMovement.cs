using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    float slide = 0f;
    bool jump = false;
    public bool crouch = false;
    bool grounded = false;
    bool isCrouching;
    public bool IsFalling;
    public RaycastHit2D ceilingInfo;
    public float distance = 2f;
    public Transform ceilingCheck;

    Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	public void Update () {
        RaycastHit2D ceilingInfo = Physics2D.Raycast(ceilingCheck.position, Vector2.up, distance);
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        slide = Input.GetAxisRaw("Vertical") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            if (ceilingInfo == false)
            {
                jump = true;
                
            }
            if (ceilingInfo == true)
            {
                jump = false;
                

            }

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

    }

    private void FixedUpdate()
    {
  
        // Move our character
        controller.Move(horizontalMove * Time.deltaTime, false, jump);
        jump = false;
        grounded = false;
        animator.SetBool("IsCrouching", crouch);

    }

    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching (bool isCrouching)
    {
        
        
    }

}
