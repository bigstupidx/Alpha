using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour {
	
	public GameObject deathEffect;
	public int effectLength = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){

		if (coll.gameObject.tag == "Player") {					
			
				coll.gameObject.GetComponent<HealthManager> ().Die ();					

		}

	}

}