using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttack : MonoBehaviour {

    public Animator animator;

    private void Start()
    {
        
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Player will be damaged");
           
        }

    }
    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Player is not damaged");
            
        }
    }


    public void Damage ()
    {

    }
}
