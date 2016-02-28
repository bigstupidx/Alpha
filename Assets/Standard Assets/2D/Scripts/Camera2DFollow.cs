using System.Collections;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {

		public bool go = false;

		private Vector2 velocity;

		public float smoothTimeY;
		public float smoothTimeX;

		public GameObject player;

     
		void Start() {
			
			StartCoroutine(Wait ());
		}

		void Update(){
			
		}

		void FixedUpdate(){

			if (go) {

				float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
				float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeX);

				posX = Mathf.Clamp(posX, 0, Mathf.Infinity);

				transform.position = new Vector3 (posX, posY, transform.position.z);


			}

		}

		IEnumerator Wait(){

			yield return new WaitForSeconds (1);

			player = GameObject.FindGameObjectWithTag("Player");
			go = true;
		}
	}
}
