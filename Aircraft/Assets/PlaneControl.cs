using UnityEngine;
using System.Collections;

public class PlaneControl : MonoBehaviour
{

	public float AmbientSpeed;
	public float RotationSpeed;

	// Use this for initialization
	void Start ()
	{
		AmbientSpeed = 0f;
		RotationSpeed = 0f;
	}

	void FixedUpdate ()
	{
		UpdateFunction ();
	}

	void UpdateFunction ()
	{
		Quaternion AddRotation = Quaternion.identity;

		float roll = 0;
		float pitch = 0;
		float yaw = 0;

		roll = Input.GetAxis ("Roll") * (Time.deltaTime * RotationSpeed);
		pitch = Input.GetAxis ("Pitch") * (Time.deltaTime * RotationSpeed);
		yaw = Input.GetAxis ("Yaw") * (Time.deltaTime * RotationSpeed);


		AddRotation.eulerAngles = new Vector3 (-pitch, yaw, - roll);
		rigidbody.rotation *= AddRotation;
	}
}
