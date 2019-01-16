using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyHealthScript : MonoBehaviour {

    public int SlimeHealth = 30;



    public Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (SlimeHealth <= 0)
        {
            anim.SetTrigger("Dead");
            Destroy(gameObject);
        }
	}

    public void TakeDamage (int damage)
    {
        SlimeHealth -= damage;
        anim.SetBool("IsHurt", true);
        Debug.Log("Damage Taken");
    }

}
