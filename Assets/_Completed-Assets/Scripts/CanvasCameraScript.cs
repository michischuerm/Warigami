using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCameraScript : MonoBehaviour {

    public Camera myCam;
    public bool pinguin;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (pinguin) {
            transform.LookAt(transform.position + myCam.transform.rotation * Vector3.back, myCam.transform.rotation * Vector3.down);
        } else {
            transform.LookAt(transform.position + myCam.transform.rotation * Vector3.back, myCam.transform.rotation * Vector3.up);
        }
		
	}
}
