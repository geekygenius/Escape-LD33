using UnityEngine;
using System.Collections;

public class CameraNavigation : MonoBehaviour {
	private Rigidbody body;
	public float speed;
	public float rotationalSpeed;
	public float height = 15f;
	private Camera cam;

	void Start () {
		body = GetComponent<Rigidbody> ();
		cam = GetComponent<Camera> ();
	}

	void Update () {
		var movementVector = new Vector3(Input.GetAxis("Horizontal") * speed, 0.0f, Input.GetAxis("Vertical") * speed);
		body.velocity =Quaternion.AngleAxis(transform.rotation.eulerAngles.y,Vector3.up) * movementVector;
		//transform.Translate (new Vector3 (Input.GetAxis ("Horizontal") * speed, 0.0f, Input.GetAxis ("Vertical") * speed));
		body.angularVelocity =  new Vector3 (0.0f, Input.GetAxis ("Rotate") * rotationalSpeed, 0.0f);
		cam.orthographicSize *= 1-Input.GetAxis ("Zoom");
	}
}
