using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    // This declares a global GameObject and Vector3 variable
    public GameObject hazard;
    public Vector3 spawnValues;

    // This declares a local and a global integer variables
    public int hazardCount;
    private int score;

    // This declares global float variables
    public float spawnWait;
    public float startWait;
    public float waveWait;

    // This declares global text variables
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    // This declares local boolean variables
    private bool gameOver;
    private bool restart;

    private void Start()
    {
        // This assigns to the variables on runtime
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;

        // This calls the functions on runtime
        UpdateScore();
        StartCoroutine (SpawnWaves());
    }

    public void Update()
    {
        // This restarts the scene when the R key is pressed
        if (restart)
        {
            if (Input.GetKeyDown (KeyCode.R))
            {
                SceneManager.LoadScene("Game");
            }
        }
    }

    
    public IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            // This spawns waves of asteroids
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            // This declares when the game can be restarted
            if (gameOver)
            {
                restartText.text = "Press 'R' to restart";
                restart = true;
                break;
            }
        }
            
    }

    // This adds the score
    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    // This updates the score
    public void UpdateScore()
    {
        scoreText.text = "Score: " + score; 
    }

    // This ends the game
    public void GameOver()
    {
        gameOverText.text = "GAME OVER";
        gameOver = true;

    }

}
