using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Fading : MonoBehaviour {

	public Texture2D fadeOutTexture;
	public float fadeSpeed = 1f;

	private int drawDepth = -1000;
	private float alpha = 1.0f;
	private int fadeDir = -1;

	void OnGUI () {
		// fade out/in the alpha value using direction, speed, and time.deltatime to convert to seconds
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		// force the number between 0 and 1 because gui.color uses alpha values between 0 and 1
		alpha = Mathf.Clamp01 (alpha);

		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);
	}

	// set fade dir to the direction parameter making scene fade in or out

	public float beginFade (int direction) {
		fadeDir = direction;
		return (fadeSpeed);
	}
	
	// OnLevelWasLoaded is called when a level is loaded.  Takes loaded level index as a parameter.
	void OnLevelWasLoaded() {		
		beginFade(-1);
	}

	public void loadLevel(int levelIndex){
		
		StartCoroutine(Wait(levelIndex));

	}

	public void loadDeath(){

		StartCoroutine(Die());

	}

	IEnumerator Wait(int levelIndex) {
		
		yield return new WaitForSeconds (1);

		SceneManager.LoadScene (levelIndex);

	}

	IEnumerator Die() {

		yield return new WaitForSeconds (1);

		SceneManager.LoadScene ("Death");

	}
}