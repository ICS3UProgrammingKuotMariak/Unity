using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // This declares global variables
    public float speed;
    public Rigidbody rb;

    public void Start()
    {
        // This moves the player's shot forward
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;


    }



}
