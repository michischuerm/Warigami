using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootRange : MonoBehaviour {

    private GameObject pinguin;
    private shots1337 shots;
    public GameObject shootRangeBar;
    private Vector3 vShootRange;

    // Use this for initialization
    void Start() {
        pinguin = GameObject.Find("Pinguin mit Waffe (rotate)");
        shots = pinguin.GetComponent<shots1337>();
        vShootRange = new Vector3(0, 1, 1);
    }

    // Update is called once per frame
    void Update() {
        vShootRange.x = shots.shotPower;
        if (vShootRange.x <= 1) {
            shootRangeBar.transform.localScale = vShootRange;
        }

    }
}
