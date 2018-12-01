using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class ShipGun : MonoBehaviour {

	public Ship ship;
	public GameObject bulletTemplate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject bullet = (GameObject)Instantiate (bulletTemplate, transform.position, bulletTemplate.transform.rotation);
			bullet.GetComponent <Bullet> ().vectorAngle = ship.angleHandler.rotation;
		}
	}
}
