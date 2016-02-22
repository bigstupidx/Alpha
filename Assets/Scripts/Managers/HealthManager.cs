using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour {

	public GameObject playerEffect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Die(){

		GameObject.Find ("Main Camera").GetComponent<Fading> ().beginFade (1);

		GameObject.Find ("Main Camera").GetComponent<Fading> ().loadDeath ();

		Destroy (Instantiate (playerEffect, transform.position, Quaternion.identity) as GameObject, 2);

		gameObject.SetActive (false);

	}
}
