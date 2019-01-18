using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyHealthScript : MonoBehaviour {

    public int SlimeHealth;

    public static bool damaged;
    public static Animator anim;
    

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        
	}
	
    void FixedUpdate ()
    {
        if (SlimeHealth <= 0)
        {
            anim.SetTrigger("Dead");
            Debug.Log("Died");
            Destroy(gameObject, 1f);
        }
    }

	// Update is called once per frame
	void Update () {

        

        if (damaged)
        {
            anim.SetBool("IsHurt", true);
        }else
        {
            anim.SetBool("IsHurt", false);
        }
        damaged = false;

    }

    public void TakeDamage (int damage)
    {
        damaged = true;
        SlimeHealth = SlimeHealth - damage;
        Debug.Log("Damage Taken " + SlimeHealth);
        
    }

}
