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

			coll.gameObject.SetActive (false);

			GameObject.Find ("Main Camera").GetComponent<Fading> ().beginFade (1);

			StartCoroutine (Wait ());

			Destroy(Instantiate(deathEffect, transform.position, Quaternion.identity) as GameObject, effectLength);

		}

		}

	IEnumerator Wait() {

		int fadeTime = 1;

		yield return new WaitForSeconds (fadeTime);

		SceneManager.LoadScene (2);

	}
}