using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UnityStandardAssets._2D {
	
public class shopButton : MonoBehaviour {

	public int money;
	public int cost;

	public string index;

	private Text buttonText;

	public bool bought;

	// Use this for initialization
	void Start () {

		index = gameObject.name;

		buttonText = gameObject.GetComponentInChildren<Text> ();

		money = PlayerPrefs.GetInt ("Money");

		if (PlayerPrefs.GetString (index) == "1") {
			bought = true;
			buttonText.text = "";
		}
	}

	public void NoneBought(){

		PlayerPrefs.SetString ("1", "0");
		PlayerPrefs.SetString ("2", "0");
		PlayerPrefs.SetString ("3", "0");
		PlayerPrefs.SetString ("4", "0");
		PlayerPrefs.SetString ("5", "0");


	}

	public void AddCoins(int amt){

		money += amt;

		PlayerPrefs.SetInt ("Money", money);

		GameObject.Find ("Coins").GetComponentInChildren<getCoins> ().refreshCoins (); // Refresh Coins Text

	}
	public void ZeroCoins(){

		money = 0;
		PlayerPrefs.SetInt ("Money", money);

		GameObject.Find ("Coins").GetComponentInChildren<getCoins> ().refreshCoins (); // Refresh Coins Text

	}

	public void Buy (){

			money = PlayerPrefs.GetInt ("Money");

			if (money >= cost && !bought) {

				bought = true;

				money -= cost;

				PlayerPrefs.SetInt ("Money", money);

				GameObject.Find ("Coins").GetComponentInChildren<getCoins> ().refreshCoins (); // Refresh Coins Text

				PlayerPrefs.SetString ("playerIndex", index);

				PlayerPrefs.SetString (index, "1");

				gameObject.GetComponentInChildren<Text> ().text = "";

				GameObject.FindGameObjectWithTag ("Player").GetComponent<HealthManager> ().Destroy ();
				GameObject.Find ("PlayerSpawn").GetComponent<shopSpawn>().Spawn (); 


			} else if (bought) {
			
				PlayerPrefs.SetString ("playerIndex", index);
				GameObject.FindGameObjectWithTag ("Player").GetComponent<HealthManager> ().Destroy ();
				GameObject.Find ("PlayerSpawn").GetComponent<shopSpawn>().Spawn (); 
			}		
		}
	}
}
