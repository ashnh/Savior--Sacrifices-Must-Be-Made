using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class ShipGun : MonoBehaviour {

	public GameObject ship;
	public GameObject bulletTemplate;
	public TimePowerHandler tph;

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

	}

}
