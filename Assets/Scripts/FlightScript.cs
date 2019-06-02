using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class FlightScript : MonoBehaviour {

	public float AmbientSpeed = 100.0f;

	public float RotationSpeed = 100.0f;

	private Rigidbody _rigidBody;

	// Use this for initialization
	void Start () 
	{
		_rigidBody = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		Quaternion AddRot = Quaternion.identity;
		float roll = 0;
		float pitch = 0;
		float yaw = 0;

		float factor = (Time.fixedDeltaTime * RotationSpeed);

		roll = (Input.GetAxis("Roll") +Input.GetAxis("Horizontal")) * factor;
		pitch = (Input.GetAxis("Pitch") + Input.GetAxis("Vertical")) * factor;
		yaw = Input.GetAxis ("Yaw") * factor;

		AddRot.eulerAngles = new Vector3(roll, yaw, pitch);
		_rigidBody.rotation *= AddRot;
		Vector3 AddPos = Vector3.forward;
		AddPos = _rigidBody.rotation * AddPos;
		_rigidBody.velocity = AddPos * (Time.fixedDeltaTime * AmbientSpeed);
	}
}