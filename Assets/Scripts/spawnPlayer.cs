using UnityEngine;
using System.Collections;

public class spawnPlayer : MonoBehaviour {

	public string index;

	public GameObject p1;
	public GameObject p2;
	public GameObject p3;
	public GameObject p4;
	public GameObject p5;

	public GameObject player;

	// Use this for initialization
	void Start () {
		SpawnPlayer ();

	}
	
	// Update is called once per frame
	public void SpawnPlayer () {
		index = PlayerPrefs.GetString ("playerIndex");

		if (index == "")
			index = "1";

		if (index == "1")
			player = p1;
		else if (index == "2")
			player = p2;
		else if (index == "3")
			player = p3;
		else if (index == "4")
			player = p4;
		else if (index == "5")
			player = p5;

		Vector3 charPos = new Vector3 (transform.position.x, transform.position.y, 0);

		Instantiate (player, charPos, Quaternion.identity);
	}
}
