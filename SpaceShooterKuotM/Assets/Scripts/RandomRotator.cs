using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    // This declares global variables
    public Rigidbody rb;
    public float tumble;

	// Use this for initialization
	void Start ()
    {
        // This randomly rotates the asteroids
        rb.angularVelocity = Random.insideUnitSphere * tumble;

	}
	

}
