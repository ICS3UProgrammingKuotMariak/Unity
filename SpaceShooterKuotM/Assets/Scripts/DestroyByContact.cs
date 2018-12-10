using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    // This declares global variables
    public GameObject explosion, playerExplosion;
    public int scoreValue;

    // This declares a local variable for the gameController
    private GameController gameController;

    private void Start()
    {
        // This looks for a gameObject with the tag "GameController" and assigns it to the gameControllerObject variable
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        // This checks to see if the gameControllerObject can find an object with the tag "GameController"
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            // This notifies the console if a GameController script cannot be found
            Debug.Log("Cannot find GameController script");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);

        // This destroys the player if they collide with an asteroid and triggers an explosion
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

            // This calls the game over procedure
            gameController.GameOver();
        }
        // This destroys an asteroid when it collides with the player's shot and triggers an explosion
        Destroy(other.gameObject);
        Destroy(gameObject);

        // This adds to the score when an asteroid is destroyed
        gameController.AddScore(scoreValue);
    }
}
