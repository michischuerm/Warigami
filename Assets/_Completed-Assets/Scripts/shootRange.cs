using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootRange : MonoBehaviour {
    //Pinguin
    private GameObject pinguin;
    private shots1337 shotsPinguin;
    private GameObject shootRangeBarPinguin;
    private Vector3 vShootRangePinguin;
    //Snake
    private GameObject snake;
    private shots1337_2 shotsSnake;
    private GameObject shootRangeBarSnake;
    private Vector3 vShootRangeSnake;

    // Use this for initialization
    void Start() {
        //Pinguin
        shootRangeBarPinguin = GameObject.Find("ShootRangeBarPinguin");
        pinguin = GameObject.Find("Pinguin mit Waffe (rotate)");
        shotsPinguin = pinguin.GetComponent<shots1337>();
        vShootRangePinguin = new Vector3(0, 1, 1);
        //Snake
        shootRangeBarSnake = GameObject.Find("ShootRangeBarSnake");
        snake = GameObject.Find("Snake (NEW)");
        shotsSnake = snake.GetComponent<shots1337_2>();
        vShootRangeSnake = new Vector3(0, 1, 1);
    }

    // Update is called once per frame
    void Update() {
        //Pinguin
        if (pinguin != null) {
            vShootRangePinguin.x = shotsPinguin.shotPower;
            if (vShootRangePinguin.x <= 1) {
                shootRangeBarPinguin.transform.localScale = vShootRangePinguin;
            }
        }
        //Snake
        if (snake != null) {
            vShootRangeSnake.x = shotsSnake.shotPower;
            if (vShootRangeSnake.x <= 1) {
                shootRangeBarSnake.transform.localScale = vShootRangeSnake;
            }
        }
        Debug.Log(vShootRangeSnake);
    }
}
