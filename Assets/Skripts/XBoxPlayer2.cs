using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XBoxPlayer2 : MonoBehaviour {
    //Inputs
    bool xbox_a = false;
    bool xbox_b = false;
    bool xbox_y = false;
    bool xbox_x = false;

    bool xbox_leftBumper = false;
    bool xbox_rightBumper = false;

    bool xbox_view = false;
    bool xbox_menu = false;

    bool xbox_rightStick = false;
    bool xbox_leftStick = false;


    float xbox_leftStickHorizontal = 0f;
    float xbox_leftStickVertical = 0f;

    float xbox_rightStickHorizontal = 0f;
    float xbox_rightStickVertical = 0f;

    float xbox_dpadHorizontal = 0f;
    float xbox_dpadVertical = 0f;

    float xbox_leftTrigger = 0f;
    float xbox_rightTrigger = 0f;

    float xbox_leftTriggerSharedAxis = 0f;
    float xbox_rightTriggerSharedAxis = 0f;


    //scaleFactor
    float scale = 0.1f;


    private float nextFire;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;


    Vector3 pivotTransVector;
    private GameObject tankPivot;


    // Use this for initialization
    void Start() {
        tankPivot = GameObject.Find("SnakeTestPivot");
        pivotTransVector.x = tankPivot.transform.position.x;
        pivotTransVector.y = tankPivot.transform.position.y;
        pivotTransVector.z = tankPivot.transform.position.z;

        /*
        //Dirty Pivot  Because Pivot is not where the object is...
        pivotTransVector.x -= 10;
        pivotTransVector.y -= 3;
        pivotTransVector.z += 6;
        */

    
    }

    // Update is called once per frame
    void Update() {

        ControllerCheck();
        //DebugKeys();
        //Shoot();
        XboxInput();

    }


	void XboxInput() {
		transform.position += new Vector3(Scale(xbox_leftStickHorizontal) * Time.deltaTime, 0, 0);
		transform.position -= new Vector3(0, 0, Scale(xbox_leftStickVertical) * Time.deltaTime);

        if (Input.GetKey(KeyCode.N)) {
            transform.Rotate(Vector3.up, -200 * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.M)) {
            transform.Rotate(Vector3.up, 200 * Time.deltaTime, Space.World);
        }

        //transform.Rotate(Vector3.up, -xbox_rightTriggerSharedAxis * 200 * Time.deltaTime, Space.World);

        //transform.RotateAround(new Vector3(637, 215.51f, -1216.329f), Vector3.up, -xbox_rightTriggerSharedAxis * 200* Time.deltaTime);

        transform.RotateAround(pivotTransVector, Vector3.up, -xbox_rightTriggerSharedAxis * 200 * Time.deltaTime);
    }


    void Shoot() {
        if (xbox_a && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }

    void ControllerCheck() {
        xbox_a = Input.GetButton("XboxA2");
        xbox_b = Input.GetButton("XboxB2");
        xbox_y = Input.GetButton("XboxY2");
        xbox_x = Input.GetButton("XboxX2");

        xbox_leftBumper = Input.GetButton("XboxLeftBumper2");
        xbox_rightBumper = Input.GetButton("XboxRightBumper2");

        xbox_view = Input.GetButton("XboxView2");
        xbox_menu = Input.GetButton("XboxMenu2");

        xbox_rightStick = Input.GetButton("XboxRightStick2");
        xbox_leftStick = Input.GetButton("XboxLeftStick2");

        xbox_leftStickHorizontal = Input.GetAxis("XboxLeftStickHorizontal2");
        xbox_leftStickVertical = Input.GetAxis("XboxLeftStickVertical2");

        xbox_rightStickHorizontal = Input.GetAxis("XboxRightStickHorizontal2");
        xbox_rightStickVertical = Input.GetAxis("XboxRightStickVertical2");

        xbox_dpadHorizontal = Input.GetAxis("XboxDPADHorizontal2");
        xbox_dpadVertical = Input.GetAxis("XboxDPADVertical2");

        xbox_leftTrigger = Input.GetAxis("XboxLeftTrigger2");
        xbox_rightTrigger = Input.GetAxis("XboxRightTrigger2");

        xbox_leftTriggerSharedAxis = Input.GetAxis("XboxLeftTriggerSharedAxis2");
        xbox_rightTriggerSharedAxis = Input.GetAxis("XboxRightTriggerSharedAxis2");

    }

    float Scale(float input) {
        return (input / scale);
    }

    private void DebugKeys() {
        if (xbox_a) { Debug.Log("Pressed A2"); }
        if (xbox_b) { Debug.Log("Pressed B2"); }
        if (xbox_y) { Debug.Log("Pressed Y2"); }
        if (xbox_x) { Debug.Log("Pressed X2"); }

        if (xbox_leftBumper) { Debug.Log("Pressed Left Bumper2"); }
        if (xbox_rightBumper) { Debug.Log("Pressed Right Bumper2"); }

        if (xbox_view) { Debug.Log("Pressed View2"); }
        if (xbox_menu) { Debug.Log("Pressed Menu2"); }

        if (xbox_rightStick) { Debug.Log("Pressed Right Stick2"); }
        if (xbox_leftStick) { Debug.Log("Pressed Left Stick2"); }

        if (xbox_leftStickHorizontal != 0f) {
            Debug.Log("Pressed Left Stick Horizontal2: " + xbox_leftStickHorizontal);
        }
        if (xbox_leftStickVertical != 0f) {
            Debug.Log("Pressed Left Stick Vertical2: " + xbox_leftStickVertical);
        }

        if (xbox_rightStickHorizontal != 0f) {
            Debug.Log("Pressed Right Stick Horizontal2: " + xbox_rightStickHorizontal);
        }
        if (xbox_rightStickVertical != 0f) {
            Debug.Log("Pressed Right Stick Vertical2: " + xbox_rightStickVertical);
        }

        if (xbox_dpadHorizontal != 0f) {
            Debug.Log("Pressed DPAD Horizontal2: " + xbox_dpadHorizontal);
        }
        if (xbox_dpadVertical != 0f) {
            Debug.Log("Pressed DPAD Vertical2: " + xbox_dpadVertical);
        }


        if (xbox_leftTrigger != 0f) {
            Debug.Log("Pressed Left Trigger2: " + xbox_leftTrigger);
        }
        if (xbox_rightTrigger != 0f) {
            Debug.Log("Pressed Right Trigger2: " + xbox_rightTrigger);
        }

        if (xbox_leftTriggerSharedAxis != 0f) {
            Debug.Log("Pressed Left Trigger Shared Axis2: " + xbox_leftTriggerSharedAxis);
        }
        if (xbox_rightTriggerSharedAxis != 0f) {
            Debug.Log("Pressed Right Trigger Shared Axis2: " + xbox_rightTriggerSharedAxis);
        }



    }
}