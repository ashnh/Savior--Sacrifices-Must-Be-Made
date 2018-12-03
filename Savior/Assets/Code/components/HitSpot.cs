using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSpot : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {

		//Debug.Log ("asdf");

		if (other.tag.Equals ("bullet")) {

			Destroy (gameObject);

		}

	}

}
