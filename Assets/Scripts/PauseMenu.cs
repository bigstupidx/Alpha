using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public GameObject pauseMenu;

	public void Pause(){

		pauseMenu.gameObject.SetActive (true);

		Time.timeScale = 0f;


	}

	public void Resume(){

		pauseMenu.gameObject.SetActive (false);

		Time.timeScale = 1f;

	}

}
