using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePowerHandler : MonoBehaviour {

	public float seconds;

	public bool reverseTime;

	float timeDown;

	// Use this for initialization
	void Start () {
		timeDown = 0f;
	}
	
	// Update is called once per frame
	void Update () {

		if (seconds > 0f && Input.GetKeyDown (KeyCode.Space)) { 
			reverseTime = true;
			timeDown = Time.timeSinceLevelLoad;
		} else if (seconds < 0f || Input.GetKeyUp (KeyCode.Space) ) 
			reverseTime = false;
		
		if (reverseTime) {

			seconds -= (Time.timeSinceLevelLoad - timeDown);

			timeDown = Time.timeSinceLevelLoad;

		}

		//Debug.Log (seconds);

	}
}
