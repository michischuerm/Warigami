using UnityEngine;
using System.Collections;

public class icefloat : MonoBehaviour {

	public float offset;

	public float speed = 0.8f;
	private Vector3 startPos;

	void Start() {
		startPos = transform.position;    
	}

	void Update() {
		transform.position = startPos + Vector3.up * Mathf.Sin (Time.time * speed);   
	}
}