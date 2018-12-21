using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Transform bar = transform.Find("Bar");
        bar.localScale = new Vector3(.5f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
