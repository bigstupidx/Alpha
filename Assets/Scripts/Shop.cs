using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

	public int highScore;
	public Text highScoreText;
	public int reqPoints = 0;


	public bool unl1 = true;
	public bool unl2 = false;
	public bool unl3 = false;
	public bool unl4 = false;

	void Start(){

		highScore = PlayerPrefs.GetInt ("highScore");

		highScoreText.text = "High Score: " + highScore.ToString ();

		if (highScore > 5)
			unl2 = true;
		if (highScore > 10)
			unl3 = true;
		if (highScore > 20)
			unl4 = true;

	}

	public void SetRequiredPoints(int Points){

		reqPoints = Points;

	}
		

	public void SetString(string Key){

		if (highScore > reqPoints) {

			PlayerPrefs.SetString ("PlayerKey", Key);


		}

	}
		
}
