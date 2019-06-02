using UnityEngine;
using System.Collections;

public class LiberatorPlayer : MonoBehaviour {

	public Rigidbody rb;
	public float initialVelocity;
	public float rotateAngle;
	public float yawRatio;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.velocity = new Vector3 (initialVelocity, 0f, 0f);
	}

	void Update() {
		// update movement
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical") ;

		// rotate along longitudinal axis
		//transform.Rotate (-moveHorizontal * yawRatio * rotateAngle, moveVertical * rotateAngle, moveHorizontal * rotateAngle);
		transform.Rotate (0, moveVertical * rotateAngle, moveHorizontal * rotateAngle);
	}
}
