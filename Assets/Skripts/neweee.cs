using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class neweee : MonoBehaviour {

    public float playerSpeed;

	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			transform.position += new Vector3 (0, 0, playerSpeed*Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.S)) {
			transform.position -= new Vector3 (0, 0, playerSpeed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.D)) {
			transform.position += new Vector3 (playerSpeed * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey (KeyCode.A)) {
			transform.position -= new Vector3 (playerSpeed * Time.deltaTime, 0,0);
		}

	}
}
