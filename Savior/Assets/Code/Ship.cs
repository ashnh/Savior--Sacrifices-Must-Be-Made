using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class Ship : MonoBehaviour {

	public float speedScale;

	public GameObject cameraObject;

	public float rotation;

	//public AngleHandler angleHandler;
	public TimeManagement tm;
	public TimePowerHandler tph;

	void Start () {
		//angleHandler = new AngleHandler (rotation);
		tm = new TimeManagement (1000);
	}
	
	void Update () {
		
		if (!Input.GetKey (KeyCode.Space)) {

			tm.update (transform.position, transform.rotation);

		} else if (tph.seconds > 0f) {

			tm.ZAWARUDO (gameObject, tph.seconds);

			cameraObject.transform.position = transform.position + new Vector3 (0f, 0f, -10f);

			return;

		}

		cameraObject.transform.position = transform.position + new Vector3 (0f, 0f, -10f);


		//movement
		float baseX = (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) ? -1f : 0f;
		baseX = (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) ? 1f : baseX;

		float baseY = (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) ? -1f : 0f;
		baseY = (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) ? 1f : baseY;

		GetComponent <Rigidbody2D> ().velocity = new Vector2 (baseX * speedScale, baseY * speedScale);

		//rotation
		transform.rotation = Quaternion.Euler (0f, 0f, Mathf.Rad2Deg * Mathf.Atan2(-Input.mousePosition.x + Screen.width/2f, Input.mousePosition.y- Screen.height/2f));
			

		//Debug.Log (tm.positions.Count);

	}
}
