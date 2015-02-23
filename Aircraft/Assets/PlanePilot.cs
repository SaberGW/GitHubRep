using UnityEngine;
using System.Collections;

public class PlanePilot : MonoBehaviour
{

	public float speed = 100.0f;

	// Use this for initialization


	void Start ()
	{
		Debug.Log ("plane pilot script added to: " + gameObject.name);
		Debug.Log (Vector3.right);
		Debug.Log (Vector3.left);
	}
	
	// Update is called once per frame
	void Update ()
	{

		Vector3 moveCamTo = transform.position - transform.forward * 10.0f + Vector3.up * 5.0f;
		float bias = 0.80f;

		Camera.main.transform.position = Camera.main.transform.position * bias +
			moveCamTo * (1.0f - bias);
		Camera.main.transform.LookAt (transform.position + transform.forward * 30.0f);

		transform.position += transform.forward * Time.deltaTime * speed;

		speed -= transform.forward.y * Time.deltaTime * 50.0f;

		if (speed < 35.0f) {
			speed = 35.0f;
		}




			


		transform.Rotate (Input.GetAxis ("Vertical"), 0.0f, - Input.GetAxis ("Horizontal") * 3.0f);

		float terrainHeightAtPlanePosition = Terrain.activeTerrain.SampleHeight (transform.position);

		if (terrainHeightAtPlanePosition > transform.position.y) {
			transform.position = new Vector3 (transform.position.x,
			                                 terrainHeightAtPlanePosition,
			                                 transform.position.z);
		}
	}
}
