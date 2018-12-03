using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class Enemy : MonoBehaviour {

	public float secondsBetweenShots;

	public float timeSinceLastShot;

	public float adjustedTimer;

	public bool shotReady;

	public bool spawned;

	public GameObject explosion; 

	public GameObject bulletTemplate;

	public GameObject spawnPoint;

	public TimePowerHandler tph;

	public Vector2 speedVector;

	TimeManagement tm;

	void Start () {

		if (speedVector.x != 0f || speedVector.y != 0f)
			transform.Rotate (0f, 0f, Mathf.Rad2Deg * Mathf.Atan2 (speedVector.y, speedVector.x) - 90);

		//Debug.Log (Mathf.Rad2Deg * Mathf.Atan2 (speedVector.y, speedVector.x));

		tm = new TimeManagement (1000);

	}


	void Update () {

		if (!Input.GetKey (KeyCode.Space)) {
			adjustedTimer += Time.deltaTime;
			tm.update (transform.position, transform.rotation);
			GetComponent <Rigidbody2D> ().velocity = speedVector;
		
		} else if (tph.seconds > 0f) {
			tm.ZAWARUDO (gameObject, tph.seconds);

			if (tm.positions.Count < 1 && spawned) 
				Destroy (gameObject);

			GetComponent <Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
			//if (timeSinceLastShot < adjustedTimer && timeSinceLastShot > adjustedTimer - secondsBetweenShots)
			//	timeSinceLastShot = 
			adjustedTimer -= Time.deltaTime;
		}

		//Debug.Log (timeSinceLastShot - secondsBetweenShots);

		if (timeSinceLastShot + secondsBetweenShots < adjustedTimer) {
			
			timeSinceLastShot = adjustedTimer;

			GameObject bullet = (GameObject)Instantiate (bulletTemplate, spawnPoint.transform.position, bulletTemplate.transform.rotation);
			bullet.GetComponent <Bullet> ().tph = this.tph;
			bullet.GetComponent <Bullet> ().vectorAngle = Mathf.Rad2Deg * Quaternion.ToEulerAngles(spawnPoint.transform.rotation).z;
			//bullet.GetComponent <Bullet> ().addedSpeed = GetComponent<Rigidbody2D> ().velocity;


		} else if (timeSinceLastShot > adjustedTimer) {

			timeSinceLastShot -= secondsBetweenShots;

		}



	}

	void OnTriggerEnter2D (Collider2D other) {

		//Debug.Log ("asdf");

		if (other.tag.Equals ("bullet")) {

			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);

		}

	}
}
