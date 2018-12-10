using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

    // This destroys a gameObject(in this case the asteroids) that leaves the boundary collider
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);   
    }
}
