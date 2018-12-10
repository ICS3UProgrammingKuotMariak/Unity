using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame()
    {
        // This loads the Game scene
        SceneManager.LoadScene("Game");
    }
    
    
    public void QuitGame()
    {
        // This closes the program
        Application.Quit();
    }



}
