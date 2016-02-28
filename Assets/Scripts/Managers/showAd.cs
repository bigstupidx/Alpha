using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class showAd : MonoBehaviour
{
	
	private string zoneId = "";
	public int rewardQty = 100;

	public void ShowAd ()
	{
		
		ShowOptions options = new ShowOptions ();

		options.resultCallback = HandleShowResult;
			
		Advertisement.Show (zoneId, options);

	}

	private void HandleShowResult (ShowResult result)
	{
		switch (result) {
		case ShowResult.Finished:

			int money = PlayerPrefs.GetInt ("Money");

			money += rewardQty;

			PlayerPrefs.SetInt ("Money", money);

			GameObject.Find ("showCoin").GetComponentInChildren<getCoins> ().refreshCoins ();

			gameObject.SetActive (false);

			break;
		case ShowResult.Skipped:
			Debug.LogWarning ("Video was skipped.");
			break;
		case ShowResult.Failed:
			Debug.LogError ("Video failed to show.");
			break;
		}
	}
}