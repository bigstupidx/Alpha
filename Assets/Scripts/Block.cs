using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour {

	Transform myTrans;
	Rigidbody2D myBody;
	public int effectLength = 2;

	public bool kill;
	public Vector2 move;


	public GameObject playerEffect;
	public GameObject enemyEffect;

	public int height;

	// Use this for initialization
	void Start () {
		myTrans = this.transform;
		myBody = this.GetComponent<Rigidbody2D> ();

		StartCoroutine (lift());

	}
	
	IEnumerator lift(){

		while (true) {

			Vector2 myVel = myBody.velocity;
			myVel.y = myTrans.up.y * height;
			myBody.velocity = myVel;

			yield return new WaitForSeconds (3);

		}		
	}

	void OnCollisionEnter2D(Collision2D coll){

		if (coll.gameObject.tag == "Player") {

			coll.gameObject.SetActive (false);

			GameObject.Find ("Main Camera").GetComponent<Fading> ().beginFade (1);

			StartCoroutine (Wait ());

			Destroy(Instantiate(enemyEffect, transform.position, Quaternion.identity) as GameObject, effectLength);

			coll.rigidbody.AddForce (move);

			Destroy(Instantiate(playerEffect, transform.position, Quaternion.identity) as GameObject, effectLength);
		}
	}

	IEnumerator Wait() {

		int fadeTime = 1;

		yield return new WaitForSeconds (fadeTime);

		SceneManager.LoadScene (2);

	}
}