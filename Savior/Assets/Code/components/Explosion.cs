using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	public bool bosu;
	public int nextLevel;

	// Update is called once per frame
	void Update () {

		transform.localScale = new Vector3 (transform.localScale.x - 0.01f, transform.localScale.y - 0.01f, transform.localScale.z - 0.01f);

		if (transform.localScale.x <= 0f) {
			if (bosu)
				UnityEngine.SceneManagement.SceneManager.LoadScene (nextLevel);
			Destroy (gameObject);
		}

	}
}
