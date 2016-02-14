using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIFunctions : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadLevel(int LevelIndex){


		GameObject.Find ("Main Camera").GetComponent<Fading> ().beginFade (1);

		StartCoroutine (Wait (LevelIndex));

	}

	public void Restart(){

		Time.timeScale = 1f;

		GameObject.Find ("Main Camera").GetComponent<Fading> ().beginFade (1);

		SceneManager.LoadScene (PlayerPrefs.GetInt ("LevelKey"));

	}

	IEnumerator Wait(int LevelIndex) {

		Time.timeScale = 1;


		int fadeTime = 1;

		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene (LevelIndex);
	}

	public void NextLevel() {

		SceneManager.LoadScene (PlayerPrefs.GetInt ("LevelKey") + 1);

	}

}
