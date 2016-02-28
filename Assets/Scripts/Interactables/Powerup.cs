using UnityEngine;
using System.Collections;

namespace UnityStandardAssets._2D {
	
public class Powerup : MonoBehaviour {

	public GameObject effect;
	public Sprite disabledSprite;
	bool boxEnabled = true;

	public Color spriteColor;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		
			if (coll.gameObject.tag == "Player" && boxEnabled) {
			
				Destroy (Instantiate (effect, transform.position, Quaternion.identity) as GameObject, 2);

				this.GetComponent<SpriteRenderer> ().sprite = disabledSprite;

				boxEnabled = false;

				coll.gameObject.GetComponent<HealthManager> ().PowerUp ();

			}
		}
	}
}
