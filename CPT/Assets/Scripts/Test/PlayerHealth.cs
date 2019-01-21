using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public AudioClip deathClip;                                 // The audio clip to play when the player dies.

    Animator anim;                                              // Reference to the Animator component.
    AudioSource playerAudio;                                    // Reference to the AudioSource component.
    public bool isDead = false;                                                // Whether the player is dead.
    bool damaged;                                               // True when the player gets damaged.

    public static PlayerHealth playerHealth;
    public static GameObject player;

    public HealthBar healthBar;
    public float damageTaken;
    public float health;

    public bool Hurt;

    void Awake()
    {
        player = gameObject;
        // Setting up the references.
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        // Set the initial health of the player.
        currentHealth = startingHealth;

        health = 1f;
        damageTaken = 0.1f;
    }


    void Update()
    {
        // If the player has just been damaged...
        if (damaged)
        {
            anim.SetBool("IsHurt", true);
            Hurt = true;

        }
        // Otherwise...
        else
        {
            anim.SetBool("IsHurt", false);
            Hurt = false;
        }

        // Reset the damaged flag.
        damaged = false;

        if (currentHealth <= 0 && isDead)
        {
            Death();
        }
    }

    void FixedUpdate ()
    {
        
    }


    public void TakeDamage(int amount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        // Set the health bar's value to the current health.
        health = health - damageTaken;
        Debug.Log(health);
        healthBar.SetSize(health);

        // Play the hurt sound effect.



        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0)
        {
            isDead = true;
        }
    }


    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;

        // Tell the animator that the player is dead.
        anim.SetTrigger("Death");

        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).

        Destroy(gameObject, 1f);

    }
}
