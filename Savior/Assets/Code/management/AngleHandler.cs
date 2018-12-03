using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp {
	public class AngleHandler {

		public float rotation;

		public AngleHandler (float startRotation) {
			rotation = startRotation;
		}

		public float normalizeAngle (float angle) {
			while (angle < 0f || angle > 360f) {
				if (angle < 0f)
					angle += 360f;
				if (angle > 360f)
					angle -= 360f;
			}
			return angle;
		}

		public void rotate2D (float angle, GameObject gameObject) {

			gameObject.transform.Rotate (new Vector3 (0f, 0f, normalizeAngle(angle - rotation)));

			rotation = angle;

		}
	}
}

