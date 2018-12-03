using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp {
	
	public class TimeManagement {

		public List <Vector3> positions;
		public List <Quaternion> rotations;

		public List <int> hitPointList;

		public TimeManagement (int capacity) {

			positions = new List<Vector3> ();
			rotations = new List<Quaternion> ();

			positions.Capacity = capacity;
			rotations.Capacity = capacity;

			hitPointList = new List <int> ();

			hitPointList.Capacity = capacity;

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

		public void update (Vector3 position, Quaternion rotation, int hitPoints, float seconds) {



		}

		public void update (Vector3 position, Quaternion rotation, int hitPoints) {

			update (position, rotation);

			if (hitPointList.Count >= hitPointList.Capacity) {
				int cap = hitPointList.Capacity;
				for (int i = 0; i < cap; i++) {

					if (i < cap -1)
						hitPointList [i] = hitPointList [i + 1];
					else
						hitPointList [i] = hitPoints; 

				}

			} else {
				hitPointList.Add (hitPoints);
			}

		}

		public void ZAWARUDO (GameObject gameObject, float secondsOfPower) {

			//Debug.Log (secondsOfPower);

			if (positions.Count >= 1 && secondsOfPower > 0f) {

				//Debug.Log (positions.Count);

				gameObject.GetComponent <Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
				gameObject.transform.position = positions [positions.Count - 1];
				gameObject.transform.rotation = rotations [rotations.Count - 1];

				positions.RemoveAt (positions.Count - 1);
				rotations.RemoveAt (rotations.Count - 1);
			}

		}

		public void ZAWARUDO (GameObject gameObject, float secondsOfPower, Ship ship) {

			ZAWARUDO (gameObject, secondsOfPower);

			if (positions.Count >= 1 && secondsOfPower > 0f) {
				ship.hitPoints = hitPointList [hitPointList.Count - 1];

				hitPointList.RemoveAt (hitPointList.Count - 1);
			}

		}

	}

}

