using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class ShipGun : MonoBehaviour {

	public GameFaces gF;

	public GameObject ship;
	public GameObject bulletTemplate;
	public TimePowerHandler tph;

	public GameObject goodShield;

	public bool shipSpawner;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown(0) && !Input.GetKey (KeyCode.Space)) {
			
			GameObject bullet = (GameObject)Instantiate (bulletTemplate, transform.position, bulletTemplate.transform.rotation);
			bullet.GetComponent <Bullet> ().tph = this.tph;
			bullet.GetComponent <Bullet> ().vectorAngle = Mathf.Rad2Deg * Quaternion.ToEulerAngles(ship.transform.rotation).z;
			bullet.GetComponent <Bullet> ().addedSpeed = ship.GetComponent<Rigidbody2D> ().velocity;

		}

		if (shipSpawner && Input.GetMouseButtonDown (1) && gF.killed <= 3 &&
			(Input.GetKey (KeyCode.Alpha1) || Input.GetKey (KeyCode.Alpha2) || Input.GetKey (KeyCode.Alpha3) || Input.GetKey (KeyCode.Alpha4))) {

			GameObject g = (GameObject)Instantiate (goodShield, transform.position, transform.rotation);

			if (Input.GetKey(KeyCode.Alpha1)) {
				g.GetComponent <Shield> ().setPersonOffered (0);
			} else if (Input.GetKey (KeyCode.Alpha2)) {
				g.GetComponent <Shield> ().setPersonOffered (1);
			} else if (Input.GetKey (KeyCode.Alpha3)) {
				g.GetComponent <Shield> ().setPersonOffered (2);
			} else if (Input.GetKey (KeyCode.Alpha4)) {
				g.GetComponent <Shield> ().setPersonOffered (3);
			}

			g.GetComponent <Shield> ().setGameFaces (gF);


			//Debug.Log (g.GetComponent <Shield> ().personOffered);

		}


	}

}
