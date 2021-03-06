﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
    public float xMin, xMax, zMin, zMax;
}

public class shots1337 : MonoBehaviour {
    //public float speed;
    //public float tilt;
    //public Boundary2 boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    public float shotPower = 0f;
    private float upPower = 0f;

    private float firstSector = 0.3f;
    private float secondSector = 0.6f;

    private GameObject crateClone;

    void Update() {
        if (shotSpawn != null) {
            if (Input.GetButton("Fire1")) {
                //Debug.Log("Fire1 has been detected");
                shotPower += Time.deltaTime;
            }

            if (Input.GetButtonUp("Fire1") && Time.time > nextFire) {

                nextFire = Time.time + fireRate;
                crateClone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;

                if (shotPower < firstSector) {
                    shotPower = 1f;
                    upPower = 1f;
                } else if (shotPower < secondSector) {
                    shotPower = 1.5f;
                    upPower = 4f;
                } else if (shotPower >= secondSector) {
                    shotPower = 2f;
                    upPower = 8f;
                }
                crateClone.GetComponent<ShotScriptPlayer1>().speed *= shotPower;
                crateClone.GetComponent<ShotScriptPlayer1>().upScale += upPower;
                crateClone.GetComponent<ShotScriptPlayer1>().shotPowerPinguin = shotPower;
                //Debug.Log("shotPower:" + shotPower);
                shotPower = 0f;
                upPower = 0f;
                //Destroy(crateClone, 5);
            }
        }
    }
}