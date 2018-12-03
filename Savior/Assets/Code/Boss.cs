using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class Boss : MonoBehaviour {

	public GameObject spawn1;
	public GameObject spawn2;
	public GameObject spawn3;
	public GameObject spawn4;

	public float secondsBetweenShots;

	public float timeSinceLastShot;

	public float adjustedTimer;

	public GameObject bulletTemplate;

	public TimePowerHandler tph;

	List <GameObject> spawnPoints;

	void Start () {

		spawnPoints = new List<GameObject> ();

		spawnPoints.Add (spawn1);
		spawnPoints.Add (spawn2);
		spawnPoints.Add (spawn3);
		spawnPoints.Add (spawn4);

		//Debug.Log (Mathf.Rad2Deg * Mathf.Atan2 (speedVector.y, speedVector.x));
	}
	
	void Update () {
		
		if (!Input.GetKey (KeyCode.Space)) {
			adjustedTimer += Time.deltaTime;

		} else if (tph.seconds > 0f) {

			//if (timeSinceLastShot < adjustedTimer && timeSinceLastShot > adjustedTimer - secondsBetweenShots)
			//	timeSinceLastShot = 
			adjustedTimer -= Time.deltaTime;
		}

		//Debug.Log (timeSinceLastShot - secondsBetweenShots);

		if (timeSinceLastShot + secondsBetweenShots < adjustedTimer) {

			timeSinceLastShot = adjustedTimer;

			foreach (GameObject g in spawnPoints) {
				GameObject bullet = (GameObject)Instantiate (bulletTemplate, g.transform.position, bulletTemplate.transform.rotation);
				bullet.GetComponent <Bullet> ().tph = this.tph;
				bullet.GetComponent <Bullet> ().vectorAngle = 180f;
			}

		} else if (timeSinceLastShot > adjustedTimer) {

			timeSinceLastShot -= secondsBetweenShots;

		}

	}
}
