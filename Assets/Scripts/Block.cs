using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	Transform myTrans;
	Rigidbody2D myBody;
	public int effectLength = 2;

	public GameObject deathEffect;

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

			Destroy(Instantiate(deathEffect, transform.position, Quaternion.identity) as GameObject, effectLength);

			Destroy (gameObject);
		}



	}

}