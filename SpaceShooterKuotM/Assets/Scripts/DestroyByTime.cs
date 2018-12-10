using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

    // This declares a global variable
    public float lifetime;

    public void Start()
    {
        // This destroys a gameObject depending on how long it has been in the scene
        Destroy(gameObject , lifetime);
    }


}
