using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class Bullet : MonoBehaviour {

	public float vectorAngle;
	public float speed;

	// Use this for initialization
	void Start () {
		
		transform.Rotate (0f, 0f, vectorAngle);
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent <Rigidbody2D> ().velocity = new Vector2 (-Mathf.Sin (vectorAngle * Mathf.Deg2Rad) * speed, Mathf.Cos (vectorAngle * Mathf.Deg2Rad) * speed);

	}
}
