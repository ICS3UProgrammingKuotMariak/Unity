using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Coin : MonoBehaviour {

    public AudioClip CoinSound;
    public AudioSource CoinObject;

    // Use this for initialization
    void Start () {
        CoinObject = gameObject.GetComponent<AudioSource>();
        CoinObject.clip = CoinSound;
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(CoinSound, this.transform.position);
            Destroy(this.gameObject);

        }
    }
}
