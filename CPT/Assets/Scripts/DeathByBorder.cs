﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathByBorder : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject)
        {
            gameManager.GameOver();
            Destroy(other.gameObject);
        }
    }
}
