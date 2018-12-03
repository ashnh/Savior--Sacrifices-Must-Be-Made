using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

class bulletValues {

	public GameObject bulletTemplate;
	public TimePowerHandler tph;
	public float vectorAngle;
	public Vector3 addedSpeed;
	public Vector3 position;
	public List <Vector3> positions;
	public List <Quaternion> rotations;

	public bulletValues (GameObject bulletTemplate, TimePowerHandler tph, float vectorAngle, Vector3 addedSpeed, Vector3 position, List <Vector3> positions, List <Quaternion> rotations) {

		this.bulletTemplate = bulletTemplate;
		this.tph = tph;
		this.vectorAngle = vectorAngle;
		this.addedSpeed = addedSpeed;
		this.position = position;

		this.positions = new List <Vector3> ();
		this.positions.Capacity = positions.Capacity;

		foreach (Vector3 p in positions) {

			this.positions.Add (p);

		}

		this.rotations = new List<Quaternion> ();
		this.rotations.Capacity = rotations.Capacity;

		foreach (Quaternion q in rotations) {

			this.rotations.Add (q);

		}

		//Debug.Log (this.positions.Count);

	}

}

public class Ship : MonoBehaviour {
	
	public GameObject badBullet;

	public float speedScale;

	public GameObject cameraObject;

	public float rotation;

	public int hitPoints;

	public float adjustedTimer;

	//public AngleHandler angleHandler;
	public TimeManagement tm;
	public TimePowerHandler tph;


	//List <GameObject> hitBullets;

	Dictionary <float, bulletValues> hitBullets;

	void Start () {
		//angleHandler = new AngleHandler (rotation);
		tm = new TimeManagement (1000);
		hitBullets = new Dictionary<float, bulletValues> ();
		//hitBullets = new List<GameObject> ();
		//hitBullets.Capacity = hitPoints;

		//Debug.Log (hitBullets.Capacity);

	}
	
	void Update () {
		
		if (!Input.GetKey (KeyCode.Space)) {

			tm.update (transform.position, transform.rotation, hitPoints);

			adjustedTimer += Time.fixedDeltaTime;

		} else if (tph.seconds > 0f) {

			tm.ZAWARUDO (gameObject, tph.seconds, this);

			if (hitBullets.ContainsKey (adjustedTimer)) {

				// GameObject bullet = (GameObject)Instantiate (bulletTemplate, spawnPoint.transform.position, bulletTemplate.transform.rotation);
				// bullet.GetComponent <Bullet> ().tph = this.tph;
				// bullet.GetComponent <Bullet> ().vectorAngle = Mathf.Rad2Deg * Quaternion.ToEulerAngles(spawnPoint.transform.rotation).z;
				// bullet.GetComponent <Bullet> ().addedSpeed = GetComponent<Rigidbody2D>.velocity; 

				GameObject bullet = (GameObject)Instantiate (hitBullets[adjustedTimer].bulletTemplate, hitBullets[adjustedTimer].position, hitBullets[adjustedTimer].bulletTemplate.transform.rotation);
				bullet.GetComponent <Bullet> ().tph = this.tph;
				bullet.GetComponent <Bullet> ().vectorAngle = hitBullets[adjustedTimer].vectorAngle;
				bullet.GetComponent <Bullet> ().addedSpeed = hitBullets[adjustedTimer].addedSpeed; 
				bullet.GetComponent <Bullet> ().createTM (hitBullets [adjustedTimer].positions, hitBullets [adjustedTimer].rotations);

				Debug.Log (bullet.GetComponent <Bullet> ().tm.positions.Count);

			}
				

			cameraObject.transform.position = transform.position + new Vector3 (0f, 0f, -10f);

			adjustedTimer -= Time.fixedDeltaTime;

			return;

		}

		cameraObject.transform.position = transform.position + new Vector3 (0f, 0f, -10f);


		//movement
		float baseX = (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) ? -1f : 0f;
		baseX = (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) ? 1f : baseX;

		float baseY = (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) ? -1f : 0f;
		baseY = (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) ? 1f : baseY;

		GetComponent <Rigidbody2D> ().velocity = new Vector2 (baseX * speedScale, baseY * speedScale);

		//rotation
		transform.rotation = Quaternion.Euler (0f, 0f, Mathf.Rad2Deg * Mathf.Atan2(-Input.mousePosition.x + Screen.width/2f, Input.mousePosition.y- Screen.height/2f));
			

		//Debug.Log (tm.positions.Count);

	}

	void OnTriggerEnter2D (Collider2D other) {

		//Debug.Log ("ok");

		if (other.tag.Equals ("hazard") && !Input.GetKey (KeyCode.Space)) {
			//Debug.Log ("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
			hitPoints--;

			if (hitBullets.Count < 4 && !hitBullets.ContainsKey(adjustedTimer)) {
				hitBullets.Add (adjustedTimer, new bulletValues (badBullet, tph, other.gameObject.GetComponent <Bullet> ().vectorAngle,
					other.gameObject.GetComponent <Bullet> ().addedSpeed, other.gameObject.transform.position, other.gameObject.GetComponent <Bullet> ().tm.positions, other.gameObject.GetComponent <Bullet> ().tm.rotations));

			}

			Destroy (other.gameObject);

		}

	}
}
