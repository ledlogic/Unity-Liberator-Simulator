using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class FlightScript : MonoBehaviour {

	public float initialSpeed = 50.0f;

	public float rotationSpeed = 45.0f;

	private Rigidbody _rigidBody;

	// Use this for initialization
	void Start () 
	{
		_rigidBody = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		Quaternion AddRot = Quaternion.identity;

		float rotationFactor = (Time.fixedDeltaTime * rotationSpeed);
		float speedFactor = (Time.fixedDeltaTime * initialSpeed);

		float roll = (Input.GetAxis("Roll") +Input.GetAxis("Horizontal")) * rotationFactor;
		float pitch = (Input.GetAxis("Pitch") + Input.GetAxis("Vertical")) * rotationFactor;
		float yaw = Input.GetAxis ("Yaw") * rotationFactor;

		AddRot.eulerAngles = new Vector3(-roll, yaw, pitch);
		_rigidBody.rotation *= AddRot;
		Vector3 AddPos = Vector3.forward;
		AddPos = _rigidBody.rotation * AddPos;
		_rigidBody.velocity = AddPos * speedFactor;
	}
}