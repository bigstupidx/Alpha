using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class backAndForth: MonoBehaviour {

	public float speed = 1;

	public float flipTime = 3;

	Rigidbody2D myBody;
	Transform myTrans;

	public bool kill = false;
	public GameObject enemyEffect;

	public int effectLength = 2;

	void Start () {
		myTrans = this.transform;
		myBody = this.GetComponent<Rigidbody2D> ();

		StartCoroutine (Flip());

	}

	void FixedUpdate(){

		// Always move Forward

		Vector2 myVel = myBody.velocity;
		myVel.x = -myTrans.right.x * speed;
		myBody.velocity = myVel;

	}

	void OnCollisionEnter2D(Collision2D coll){

		if (coll.gameObject.tag == "Player") {

			Destroy (Instantiate (enemyEffect, transform.position, Quaternion.identity) as GameObject, 2);

			if (kill) {

				coll.gameObject.GetComponent<HealthManager> ().Die ();

				Destroy (gameObject);

			} else {

				Destroy (gameObject);
			}
		}

	}

	IEnumerator Flip(){

		while(true){

			Vector3 currRot = myTrans.eulerAngles;
			currRot.y += 180;
			myTrans.eulerAngles = currRot;

			yield return new WaitForSeconds (flipTime);

		}
	}
}