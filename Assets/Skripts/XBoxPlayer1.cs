using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XBoxPlayer1 : MonoBehaviour {
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



    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        ControllerCheck();
        //DebugKeys();
        //Shoot();
        XboxInput();


    }

    void XboxInput() {
        //LeftStick     Moving
        transform.position += new Vector3(Scale(xbox_leftStickHorizontal) * Time.deltaTime, 0, 0);
        transform.position -= new Vector3(0, 0, Scale(xbox_leftStickVertical) * Time.deltaTime);


        if (Input.GetKey(KeyCode.Q)) {
            transform.Rotate(Vector3.up, -200 * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.E)) {
            transform.Rotate(Vector3.up, 200 * Time.deltaTime, Space.World);
        }

        transform.Rotate(Vector3.up, -xbox_rightTriggerSharedAxis * 200 * Time.deltaTime, Space.World);



        //RightStick Turning
        //transform.Rotate(Vector3.up, xbox_rightStickHorizontal * 50 * Time.deltaTime, Space.World);
        //Right And Left Triffer turning
    }



    void Shoot() {

        if (xbox_a && Time.time > nextFire) {
            Debug.Log("Hi");
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }

    void ControllerCheck() {
        xbox_a = Input.GetButton("XboxA1");
        xbox_b = Input.GetButton("XboxB1");
        xbox_y = Input.GetButton("XboxY1");
        xbox_x = Input.GetButton("XboxX1");

        xbox_leftBumper = Input.GetButton("XboxLeftBumper1");
        xbox_rightBumper = Input.GetButton("XboxRightBumper1");

        xbox_view = Input.GetButton("XboxView1");
        xbox_menu = Input.GetButton("XboxMenu1");

        xbox_rightStick = Input.GetButton("XboxRightStick1");
        xbox_leftStick = Input.GetButton("XboxLeftStick1");

        xbox_leftStickHorizontal = Input.GetAxis("XboxLeftStickHorizontal1");
        xbox_leftStickVertical = Input.GetAxis("XboxLeftStickVertical1");

        xbox_rightStickHorizontal = Input.GetAxis("XboxRightStickHorizontal1");
        xbox_rightStickVertical = Input.GetAxis("XboxRightStickVertical1");

        xbox_dpadHorizontal = Input.GetAxis("XboxDPADHorizontal1");
        xbox_dpadVertical = Input.GetAxis("XboxDPADVertical1");

        xbox_leftTrigger = Input.GetAxis("XboxLeftTrigger1");
        xbox_rightTrigger = Input.GetAxis("XboxRightTrigger1");

        xbox_leftTriggerSharedAxis = Input.GetAxis("XboxLeftTriggerSharedAxis1");
        xbox_rightTriggerSharedAxis = Input.GetAxis("XboxRightTriggerSharedAxis1");

    }

    float Scale(float input) {
        //Debug.Log(input);
        return (input / scale);
    }

    private void DebugKeys() {
        if (xbox_a) { Debug.Log("Pressed A1"); }
        if (xbox_b) { Debug.Log("Pressed B1"); }
        if (xbox_y) { Debug.Log("Pressed Y1"); }
        if (xbox_x) { Debug.Log("Pressed X1"); }

        if (xbox_leftBumper) { Debug.Log("Pressed Left Bumper1"); }
        if (xbox_rightBumper) { Debug.Log("Pressed Right Bumper1"); }

        if (xbox_view) { Debug.Log("Pressed View1"); }
        if (xbox_menu) { Debug.Log("Pressed Menu1"); }

        if (xbox_rightStick) { Debug.Log("Pressed Right Stick1"); }
        if (xbox_leftStick) { Debug.Log("Pressed Left Stick1"); }

        if (xbox_leftStickHorizontal != 0f) {
            Debug.Log("Pressed Left Stick Horizontal1: " + xbox_leftStickHorizontal);
        }
        if (xbox_leftStickVertical != 0f) {
            Debug.Log("Pressed Left Stick Vertical1: " + xbox_leftStickVertical);
        }

        if (xbox_rightStickHorizontal != 0f) {
            Debug.Log("Pressed Right Stick Horizontal1: " + xbox_rightStickHorizontal);
        }
        if (xbox_rightStickVertical != 0f) {
            Debug.Log("Pressed Right Stick Vertical1: " + xbox_rightStickVertical);
        }

        if (xbox_dpadHorizontal != 0f) {
            Debug.Log("Pressed DPAD Horizontal1: " + xbox_dpadHorizontal);
        }
        if (xbox_dpadVertical != 0f) {
            Debug.Log("Pressed DPAD Vertical1: " + xbox_dpadVertical);
        }


        if (xbox_leftTrigger != 0f) {
            Debug.Log("Pressed Left Trigger1: " + xbox_leftTrigger);
        }
        if (xbox_rightTrigger != 0f) {
            Debug.Log("Pressed Right Trigger1: " + xbox_rightTrigger);
        }

        if (xbox_leftTriggerSharedAxis != 0f) {
            Debug.Log("Pressed Left Trigger Shared Axis1: " + xbox_leftTriggerSharedAxis);
        }
        if (xbox_rightTriggerSharedAxis != 0f) {
            Debug.Log("Pressed Right Trigger Shared Axis1: " + xbox_rightTriggerSharedAxis);
        }



    }
}