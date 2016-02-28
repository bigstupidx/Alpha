using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class getCoins : MonoBehaviour {

	public int Coins;

	// Use this for initialization
	void Start () {
		
		refreshCoins ();

	}
	
	// Update is called once per frame
	public void refreshCoins () {
	
		Coins = PlayerPrefs.GetInt ("Money");

		Text text = GetComponent<Text> ();

		text.text = "Coins: " + Coins;

	}
}