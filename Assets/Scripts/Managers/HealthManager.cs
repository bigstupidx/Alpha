using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{

	public class HealthManager : MonoBehaviour
	{

		public GameObject playerEffect;

		public float enhanced;
		public Color spriteColor;
		public int jumpAddForce;

		// Use this for initialization
		void Start ()
		{
			
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void PowerUp ()
		{

			Vector3 enhancedScale = new Vector3 (transform.localScale.x * enhanced, transform.localScale.y * enhanced, transform.localScale.z * enhanced);

			transform.localScale = enhancedScale;

			transform.gameObject.GetComponent<PlatformerCharacter2D> ().powerUp (jumpAddForce);

			gameObject.GetComponent<SpriteRenderer> ().color = Color.red;

			StartCoroutine (Wait ());

		}

		public void Die ()
		{

			GameObject.Find ("Main Camera").GetComponent<Fading> ().beginFade (1);

			GameObject.Find ("Main Camera").GetComponent<Fading> ().loadDeath ();

			Destroy (Instantiate (playerEffect, transform.position, Quaternion.identity) as GameObject, 2);

			gameObject.SetActive (false);		

		}

		public void Destroy ()
		{
			
			Destroy (gameObject);
		}

		IEnumerator Wait ()
		{
		
			yield return new WaitForSeconds (5);

			Vector3 normalScale = new Vector3 (transform.localScale.x / enhanced, transform.localScale.y / enhanced, transform.localScale.z / enhanced);

			transform.localScale = normalScale;

			transform.gameObject.GetComponent<PlatformerCharacter2D> ().powerDown (jumpAddForce);
			gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
		}
	}
}
