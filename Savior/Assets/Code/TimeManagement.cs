using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp {
	
	public class TimeManagement {

		public List <Vector3> positions;
		public List <Quaternion> rotations;

		public TimeManagement (int capacity) {

			positions = new List<Vector3> ();
			rotations = new List<Quaternion> ();

			positions.Capacity = capacity;
			rotations.Capacity = capacity;

		}

		public void update (Vector3 position, Quaternion rotation) {

			if (positions.Count >= positions.Capacity) {
				int cap = positions.Capacity;
				for (int i = 0; i < cap; i++) {
					
					if (i < cap -1)
						positions [i] = positions [i + 1];
					else
						positions [i] = position; 
				
				}

			} else {
				positions.Add (position);
			}

			if (rotations.Count >= rotations.Capacity) {
				int cap = rotations.Capacity;
				for (int i = 0; i < cap; i++) {

					if (i < cap -1)
						rotations [i] = rotations [i + 1];
					else
						rotations [i] = rotation; 

				}

			} else {
				rotations.Add (rotation);
			}

		}

		public void ZAWARUDO (GameObject gameObject, float secondsOfPower) {

			Debug.Log (secondsOfPower);

			if (positions.Count >= 1 && secondsOfPower > 0f) {
				gameObject.GetComponent <Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
				gameObject.transform.position = positions [positions.Count - 1];
				gameObject.transform.rotation = rotations [rotations.Count - 1];

				positions.RemoveAt (positions.Count - 1);
				rotations.RemoveAt (rotations.Count - 1);
			}

		}

	}

}

