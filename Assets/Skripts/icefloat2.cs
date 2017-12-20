using UnityEngine;
using System.Collections;

public class icefloat2 : MonoBehaviour {

	public float offset;


	public float speed = 0.8f;
	private Vector3 startPos;

	private Vector3 scaleVector;
	public float scaleFactor = 0.01f;

	void Start() {
		scaleVector = new Vector3(1, scaleFactor, 1);
		startPos = transform.position;
	}

	void Update() {

		transform.position = startPos + Vector3.Scale(Vector3.up * Mathf.Sin(Time.time * speed), scaleVector);
		//transform.position = startPos + Vector3.up * Mathf.Sin(Time.time * speed);
		// Debug.Log(transform.position);




	}

}