using System;
using UnityEngine;
using UnityEngine.SceneManagement;

    public class Restarter : MonoBehaviour
    {

		void OnCollisionEnter2D(Collision2D coll){

			if (coll.gameObject.tag == "Player") {
			SceneManager.LoadScene (3);
		}
    }
}
