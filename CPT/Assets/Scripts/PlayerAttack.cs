using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerAttack : MonoBehaviour {

    public CustomCharacterController controller;

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public static bool Attacking;
    public static int damage;

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update () {

        
            if (Input.GetButtonDown("Attack") && Time.time > timeBtwAttack)
            {
                damage = 5;
                timeBtwAttack = Time.time + startTimeBtwAttack;
                Attacking = true;
                anim.SetTrigger("PlayerAttack");
                

            }else if (Input.GetButtonUp("Attack"))
            {
                anim.ResetTrigger("PlayerAttack");
                Attacking = false;
            }

            if (Input.GetButtonDown("HeavyAttack") && Time.time > timeBtwAttack)
            {
                damage = 10;
                timeBtwAttack = Time.time + startTimeBtwAttack;
                Attacking = true;
                anim.SetTrigger("PlayerHeavyAttack");

            }
            else if (Input.GetButtonUp("HeavyAttack"))
            {
                anim.ResetTrigger("PlayerHeavyAttack");
                Attacking = false;
            }

       
    }

}
