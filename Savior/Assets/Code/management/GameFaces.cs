using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFaces : MonoBehaviour {

	public GameObject s1;
	public GameObject s2;
	public GameObject s3;
	public GameObject s4;

	public int killed;

	public void kill (int x) {

		switch (x) {
		case 0:
			Destroy (s1);
			PlayerPrefs.SetInt ("a", 0);
			break;
		case 1:
			Destroy (s2);
			PlayerPrefs.SetInt ("p", 0);
			break;
		case 2:
			Destroy (s3);
			PlayerPrefs.SetInt ("e", 0);
			break;
		case 3:
			Destroy (s4);
			PlayerPrefs.SetInt ("s", 0);
			break;
		}

		killed++;

		//Debug.Log (x);

	}

	// Use this for initialization
	void Start () {
		//killed = (PlayerPrefs.GetInt ("a") + PlayerPrefs.GetInt ("p") + PlayerPrefs.GetInt ("r") + PlayerPrefs.GetInt ("s"));



		if (PlayerPrefs.GetInt ("a") == 0)
			kill (0);
		if (PlayerPrefs.GetInt ("p") == 0)
			kill (1);
		if (PlayerPrefs.GetInt ("e") == 0)
			kill (2);
		if (PlayerPrefs.GetInt ("s") == 0)
			kill (3);
	}
	
	// Update is called once per frame
	void Update () {
		

	}
}
