using UnityEngine;
using System.Collections;

public class Slime : MonoBehaviour {

	public float speed = 1;

	public float flipTime = 3;

	public LayerMask enemyMask;
	Rigidbody2D myBody;
	Transform myTrans;


	public GameObject deathEffect;
	public int effectLength = 2;

	void Start () {
		myTrans = this.transform;
		myBody = this.GetComponent<Rigidbody2D> ();

		StartCoroutine (flip());

	}

	void FixedUpdate(){



		// Always move Forward

		Vector2 myVel = myBody.velocity;
		myVel.x = -myTrans.right.x * speed;
		myBody.velocity = myVel;

	}

	void OnCollisionEnter2D(Collision2D coll){

		if (coll.gameObject.tag == "Player") {

			Destroy(Instantiate(deathEffect, transform.position, Quaternion.identity) as GameObject, effectLength);

			Destroy (gameObject);

		}			

	}

	IEnumerator flip(){
		
		while(true){

			Vector3 currRot = myTrans.eulerAngles;
			currRot.y += 180;
			myTrans.eulerAngles = currRot;

			yield return new WaitForSeconds (flipTime);

		}
	}
}