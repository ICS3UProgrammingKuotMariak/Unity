using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAppear : MonoBehaviour {

    public Canvas CanvasObject;
    private bool isShowing;

    void Start()
    {
        CanvasObject = GetComponent<Canvas>();
        DisableCanvas();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CanvasObject.enabled = !CanvasObject.enabled;
        }
    }
    void DisableCanvas ()
    {
        CanvasObject.enabled = false;
    }

}
