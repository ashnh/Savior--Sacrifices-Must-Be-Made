using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class EnemySpawner : MonoBehaviour {

	//TimeManagement tm;

	public float adjustedTimer;

	public float timeSinceLastShot;

	public float secondsBetweenShots;

	public float secondsBetweenEnemyShots;

	public TimePowerHandler tph;

	public GameObject enemyTemplate;

	public Vector2 speedVector;

	void Start () {

		//tm = new TimeManagement (1000);


	}
	
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

		if (timeSinceLastShot + secondsBetweenShots < adjustedTimer) {

			timeSinceLastShot = adjustedTimer;

			GameObject enemy = (GameObject)Instantiate (enemyTemplate, transform.position, enemyTemplate.transform.rotation);
			enemy.GetComponent <Enemy> ().tph = this.tph;
			enemy.GetComponent <Enemy> ().speedVector = speedVector;
			enemy.GetComponent <Enemy> ().secondsBetweenShots = secondsBetweenEnemyShots;
			enemy.GetComponent <Enemy> ().spawned = true;

		} else if (timeSinceLastShot > adjustedTimer) {

			timeSinceLastShot -= secondsBetweenShots;

		}

	}
}
