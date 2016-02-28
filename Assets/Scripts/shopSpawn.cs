using UnityEngine;
using System.Collections;

public class shopSpawn : MonoBehaviour {

	public string index;

	public GameObject p1;
	public GameObject p2;
	public GameObject p3;
	public GameObject p4;
	public GameObject p5;

	public GameObject player;

	// Use this for initialization
	void Start () {
		
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
		
		Spawn ();
	}

	public void Spawn(){

		index = PlayerPrefs.GetString ("playerIndex");

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

		Instantiate (player, transform.position, Quaternion.identity);

	}
}
