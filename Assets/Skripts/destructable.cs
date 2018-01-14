using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructable : MonoBehaviour {

    public GameObject destroyedVersion;
    private Vector3 objectPosition;
    public AudioClip[] clip;


    void Start() {
        objectPosition = transform.position;
    }

    void OnCollisionEnter(Collision collision) {

        if (collision.rigidbody.mass > 3) {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(clip[Random.Range(0, clip.Length)], objectPosition);
            Destroy(gameObject);
        }
    }
}
