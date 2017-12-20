using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupFall : MonoBehaviour {
    private GameObject pickup;
    private Rigidbody rb;

    public float randomMin;
    public float randomMax;
    private float time;


    // Use this for initialization
    void Start() {
        time = Random.Range(randomMin, randomMax);
        //Debug.Log(time);
        rb = gameObject.GetComponent<Rigidbody>();
        StartCoroutine(Example());
    }

    // Update is called once per frame
    void Update() {


    }

    IEnumerator Example() {
        yield return new WaitForSeconds(time);
        rb.constraints = RigidbodyConstraints.None;
    }

}

