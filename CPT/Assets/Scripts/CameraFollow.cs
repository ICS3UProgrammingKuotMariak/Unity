using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame

    void Update ()
    {
        if (player == null)
        {
            gameObject.GetComponent<CameraFollow>().enabled = false;
        }
    }

	void LateUpdate () {
        

        transform.position = target.position + offset;
       
        
	}

}
