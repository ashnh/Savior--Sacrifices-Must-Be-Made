using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagement : MonoBehaviour {

	public float time;
	public int nextLevel;

	public TimePowerHandler tph;

	public float adjustedTimer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (!Input.GetKey (KeyCode.Space)) {
			adjustedTimer += Time.deltaTime;
			//tm.update (transform.position, transform.rotation);

		} else if (tph.seconds > 0f) {
			//tm.ZAWARUDO (gameObject, tph.seconds);

			//if (timeSinceLastShot < adjustedTimer && timeSinceLastShot > adjustedTimer - secondsBetweenShots)
			//	timeSinceLastShot = 
			adjustedTimer -= Time.deltaTime;
		}

		if (time < adjustedTimer) {
			
			UnityEngine.SceneManagement.SceneManager.LoadScene (nextLevel);
		}
	}
}
