using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScrene : MonoBehaviour {

	public UnityEngine.UI.Text text;

	public void start (int nextLevel) {
		UnityEngine.SceneManagement.SceneManager.LoadScene (nextLevel);
	}

	// Use this for initialization
	void Start () {
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex == 0) {

			PlayerPrefs.SetInt ("a", 1);
			PlayerPrefs.SetInt ("p", 1);
			PlayerPrefs.SetInt ("e", 1);
			PlayerPrefs.SetInt ("s", 1);

		}
	}
	
	// Update is called once per frame
	void Update () {

		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex != 0) {
			text.text = "" + ((PlayerPrefs.GetInt ("a") + PlayerPrefs.GetInt ("p") + PlayerPrefs.GetInt ("r") + PlayerPrefs.GetInt ("s"))) + " / 5 souls saved";
		}

	}
}
