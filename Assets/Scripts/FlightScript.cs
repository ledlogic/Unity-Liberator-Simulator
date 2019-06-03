using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class FlightScript : MonoBehaviour {

	public float initialSpeed = 50.0f;

	public float rotationSpeed = 45.0f;

	public float deltaKey = 3.0f;

	private Rigidbody _rigidBody;

	// Use this for initialization
	void Start () 
	{
		_rigidBody = GetComponent<Rigidbody>();
		_rigidBody.velocity = new Vector3 (initialSpeed, 0f, 0f);
	}

	void FixedUpdate()
	{
		Quaternion AddRot = Quaternion.identity;

		float rotationFactor = (Time.fixedDeltaTime * rotationSpeed);
		float speedFactor = (Time.fixedDeltaTime * initialSpeed);

		float roll = (Input.GetAxis("Roll") +Input.GetAxis("Horizontal")) * rotationFactor;
		float pitch = (Input.GetAxis("Pitch") + Input.GetAxis("Vertical")) * rotationFactor;
		float yaw = Input.GetAxis ("Yaw") * rotationFactor;

		bool roll2Neg = Input.GetKey ("[4]");
		bool roll2Pos = Input.GetKey ("[6]");
		roll += deltaKey * ((roll2Neg ? -1.0f: 0.0f) + (roll2Pos ? 1.0f: 0.0f));

		bool pitch2Neg = Input.GetKey ("[8]");
		bool pitch2Pos = Input.GetKey ("[2]");
		pitch += deltaKey * ((pitch2Neg ? -1.0f: 0.0f) + (pitch2Pos ? 1.0f: 0.0f));

		bool yaw2Neg = Input.GetKey ("[7]");
		bool yaw2Pos = Input.GetKey ("[9]");
		yaw += deltaKey * ((yaw2Neg ? -1.0f: 0.0f) + (yaw2Pos ? 1.0f: 0.0f));

		AddRot.eulerAngles = new Vector3(-roll, yaw, pitch);
		_rigidBody.rotation *= AddRot;
	}
}