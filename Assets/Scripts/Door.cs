using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

	public int effectLength = 3;
	public GameObject deathEffect;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){

		if (coll.gameObject.tag == "Player") {

			coll.gameObject.SetActive (false);

			//Vector2 force = new Vector2 (0, 5000);
			//coll.rigidbody.AddForce(force);

			Destroy(Instantiate(deathEffect, transform.position, Quaternion.identity) as GameObject, effectLength);

			GameObject.Find ("Main Camera").GetComponent<Fading> ().beginFade (1);

			StartCoroutine (Wait ());
		}
	}

	IEnumerator Wait() {
		
		int fadeTime = 1;

		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene (1);

	}
}
