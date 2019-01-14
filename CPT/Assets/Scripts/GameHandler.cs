using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

    [SerializeField] private HealthBar healthBar;
    public GameObject player;
    public GameObject slime;
    public int playerHealth = 100;

	// Use this for initialization
	void Start () {
        

	}
	
	// Update is called once per frame
	void Update () {
		if (SlimeAi.PlayerIsDamaged == true)
        {
            healthBar.SetSize(0.4f);
        }
	}

}
