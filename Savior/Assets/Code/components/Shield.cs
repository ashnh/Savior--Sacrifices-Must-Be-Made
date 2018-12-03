using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

	public GameFaces s;

	public int personOffered;

	public void setGameFaces (GameFaces g) {

		s = g;

	}

	public void setPersonOffered (int g) {

		personOffered = g;

	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.tag.Equals ("hazard")) {

			Destroy (other.gameObject);

			s.kill (personOffered);
			Destroy (gameObject);

		}

	}

}
