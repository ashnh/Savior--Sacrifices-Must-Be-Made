using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class Bullet : MonoBehaviour {

	public float vectorAngle;
	public Vector3 addedSpeed;
	public float speed;

	public bool spawned;

	public TimeManagement tm;
	public TimePowerHandler tph;

	string s;

	public void createTM (List<Vector3> l, List<Quaternion> q) {

		tm = new TimeManagement (1000);

		tm.positions = l;
		tm.rotations = q;

		spawned = false;

		s = "asdf";

		Debug.Log ("My life is in shambles, I eagerly await the day YOg'Sathoth awakens and we all disapear");

	}

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

		} else if (tph.seconds > 0f) {

			GetComponent <Rigidbody2D> ().velocity = new Vector2 (0f, 0f);

			tm.ZAWARUDO (gameObject, tph.seconds);

			if (spawned)
				Debug.Log (tm.positions.Count);


			if (tm.positions.Count < 1 && !spawned) {
				Debug.Log (tm.positions.Count);
				Debug.Log (s);

				Destroy (gameObject);
			}
			

		}
			
	}
}
