﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            
            
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            
            SlimeAi.PlayerFound = false;
        }
    }

}
