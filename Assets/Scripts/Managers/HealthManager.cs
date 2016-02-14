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
		GameObject.Find ("Main Camera").GetComponent<Fading> ().loadLevel (3);

		Destroy (Instantiate (playerEffect, transform.position, Quaternion.identity) as GameObject, 2);

		gameObject.SetActive (false);

	}

	IEnumerator Wait() {

		int fadeTime = 1;

		yield return new WaitForSeconds (fadeTime);

		SceneManager.LoadScene (3);

	}
}
