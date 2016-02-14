using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	public int effectLength = 2;
	public GameObject deathEffect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll){

		if (coll.gameObject.tag == "Player") {
			
			Destroy(Instantiate(deathEffect, transform.position, Quaternion.identity) as GameObject, effectLength);

			Destroy (gameObject);

		}

	}
}
