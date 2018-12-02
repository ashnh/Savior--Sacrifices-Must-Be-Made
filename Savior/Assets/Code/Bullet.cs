using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class Bullet : MonoBehaviour {

	public float vectorAngle;
	public Vector3 addedSpeed;
	public float speed;

	public TimeManagement tm;
	public TimePowerHandler tph;

	// Use this for initialization
	void Start () {
		
		transform.Rotate (0f, 0f, vectorAngle);

		tm = new TimeManagement (1000);

	}
	
	// Update is called once per frame
	void Update () {
		if (!Input.GetKey (KeyCode.Space) || tph.seconds <= 0f) {
		
			GetComponent <Rigidbody2D> ().velocity = new Vector2 (-Mathf.Sin (vectorAngle * Mathf.Deg2Rad) * speed + addedSpeed.x, Mathf.Cos (vectorAngle * Mathf.Deg2Rad) * speed + addedSpeed.y);
			tm.update (transform.position, transform.rotation);

		} else {

			tm.ZAWARUDO (gameObject, tph.seconds);

			if (tm.positions.Count < 1) 
				Destroy (gameObject);
			

		}
			
	}
}
