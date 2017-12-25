using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public float speed;
	public float lifetime;
	public float upScale;

    public AudioClip[] shootSounds;
    private AudioSource audioSource;

	void Start ()
	{
		Rigidbody rb = (Rigidbody)GetComponent(typeof(Rigidbody));
		rb.velocity =  transform.forward * speed + transform.up * upScale;

        audioSource = gameObject.GetComponent<AudioSource>();
        playRandomSoundOnStart();
	}

    void playRandomSoundOnStart() {
        audioSource.clip = shootSounds[Random.Range(0, shootSounds.Length)];
        audioSource.Play();
    }

    void  Awake ()
	{
		Destroy(gameObject, lifetime);
	}
}