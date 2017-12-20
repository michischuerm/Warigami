using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    public float playerSpeed;

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.position += new Vector3 (0, 0, playerSpeed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.position -= new Vector3 (0, 0, playerSpeed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += new Vector3 (playerSpeed * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position -= new Vector3 (playerSpeed * Time.deltaTime, 0,0);
		}

	}
}
