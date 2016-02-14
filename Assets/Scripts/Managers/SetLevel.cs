using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SetLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt("LevelKey", SceneManager.GetActiveScene().buildIndex);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}