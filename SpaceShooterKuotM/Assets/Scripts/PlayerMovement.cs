using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This allows the function to be "seen" by the Unity inspector while being in a separate class
[System.Serializable]

// This declares public variables for the boundary
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerMovement : MonoBehaviour {

    // This declares global variables
    public Rigidbody rb;
    public float speed;
    public float tilt;
    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    // This declares local variables
    private float nextFire;
    private AudioSource audioSource;

    // This gets the audio component on runtime
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();        
    }

    // This fires the player's weapon when the left mouse button is clicked
    public void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject clone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            audioSource.Play();       
        }
    
    }

    // This moves the player
    public void FixedUpdate()
    {
        rb = GetComponent<Rigidbody>();

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;


        // This tilts the player's ship
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
         );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }

}
