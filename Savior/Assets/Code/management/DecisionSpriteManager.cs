using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionSpriteManager : MonoBehaviour {

	public Ship ship;

	public TextMesh a;
	public TextMesh p;
	public TextMesh e;
	public TextMesh s;

	public string a4;
	public string p4;
	public string e4;
	public string s4;

	public string a3;
	public string p3;
	public string e3;
	public string s3;

	public string a2;
	public string p2;
	public string e2;
	public string s2;

	public string a1;
	public string p1;
	public string e1;
	public string s1;

	float startHealth;

	Quaternion rot;

	// Use this for initialization
	void Start () {
		rot = new Quaternion (0f, 0f, 0f, 0f);
		startHealth = ship.hitPoints;
	}
	
	// Update is called once per frame
	void Update () {

		transform.rotation = rot;
		transform.position = ship.gameObject.transform.position;

		if (startHealth != ship.hitPoints) {
			a.text = "";
			p.text = "";
			e.text = "";
			s.text = "";
			return;
		}

		switch (ship.hitPoints) {
		case 4:
			if (a != null)
				a.text = a4;
			if (p != null)
			p.text = p4;
			if (e != null)
			e.text = e4;
			if (s != null)
			s.text = s4;
			break;
		case 3:
			if (a != null)
			a.text = a3;
			if (p != null)
			p.text = p3;
			if (e != null)
			e.text = e3;
			if (s != null)
			s.text = s3;

			break;
		case 2:
			if (a != null)
			a.text = a2;
			if (p != null)
			p.text = p2;
			if (e != null)
			e.text = e2;
			if (s != null)
			s.text = s2;

			break;
		case 1:
			if (a != null)
			a.text = a1;
			if (p != null)
			p.text = p1;
			if (e != null)
			e.text = e1;
			if (s != null)
			s.text = s1;

			break;
		default:
			a.text = "aaaaaaaaaaaaa";
			p.text = "aaaaaaaaaaaaa";
			e.text = "aaaaaaaaaaaaa";
			s.text = "aaaaaaaaaaaaa";

			break;
		}

	}
}
