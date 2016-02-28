using UnityEngine;
using System.Collections;

public class MoneyManager : MonoBehaviour {

	public int Money;

	void Start () {

		Money = PlayerPrefs.GetInt ("Money");

		UpdateMoney ();
	}

	public void AddMoney(int amount) {

		Money += amount;
		UpdateMoney ();

	}

	void UpdateMoney(){

		PlayerPrefs.SetInt ("Money", Money);

	}

}
