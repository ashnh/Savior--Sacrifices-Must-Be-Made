using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class Ship : MonoBehaviour {

	public float speedScale;

	public GameObject cameraObject;

	public float rotation;

	public AngleHandler angleHandler;

	// Use this for initialization
	void Start () {
		angleHandler = new AngleHandler (rotation);
	}

	/*public float normalizeAngle (float angle) {
		while (angle < 0f || angle > 360f) {
			if (angle < 0f)
				angle += 360f;
			if (angle > 360f)
				angle -= 360f;
		}
		return angle;
	}

	public void rotate2D (float angle) {

		transform.Rotate (new Vector3 (0f, 0f, normalizeAngle(angle - rotation)));

		rotation = angle;

	}*/
	
	// Update is called once per frame
	void Update () {

		//movement
		float baseX = (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) ? -1f : 0f;
		baseX = (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) ? 1f : baseX;

		float baseY = (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) ? -1f : 0f;
		baseY = (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) ? 1f : baseY;

		GetComponent <Rigidbody2D> ().velocity = new Vector2 (baseX * speedScale, baseY * speedScale);

		//rotation
		//Vector3 mousePos = cameraObject.GetComponent<Camera>().ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0f));

		cameraObject.transform.position = transform.position + new Vector3 (0f, 0f, -10f);
		angleHandler.rotate2D (Mathf.Rad2Deg * Mathf.Atan2(-Input.mousePosition.x + Screen.width/2f, Input.mousePosition.y- Screen.height/2f), gameObject);

		//Debug.Log ((Input.mousePosition.x - Screen.width/2f) + "\t" + (Input.mousePosition.y- Screen.height/2f));

	}
}
