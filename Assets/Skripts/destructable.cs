using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructable : MonoBehaviour {

    public GameObject destroyedVersion;



    void Start() {

    }

    void OnCollisionEnter(Collision collision) {

        if (collision.rigidbody.mass > 3) {

            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
