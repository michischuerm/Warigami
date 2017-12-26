using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
    public float speed;
    public float lifetime;
    public float upScale;



    public AudioClip[] shootSounds;

    [Range(0, 36f)]//Value below
    public float pitchRange = -36f;

    public float minVolumeRange = 0.8f;
    public float maxVolumeRange = 1f;


    private AudioSource audioSource;
    private int randomValueFromSoundArray;
    private static int previousRandomValue = 0;
    private float pitchOctaveValue = 1.05946f;



    void Start() {
        Rigidbody rb = (Rigidbody)GetComponent(typeof(Rigidbody));
        rb.velocity = transform.forward * speed + transform.up * upScale;

        audioSource = gameObject.GetComponent<AudioSource>();
        disableRandomAudioSuccessively();
        playRandomSoundOnStart();

    }

    void Awake() {
        Destroy(gameObject, lifetime);
    }

    void playRandomSoundOnStart() {
        audioSource.clip = shootSounds[randomValueFromSoundArray];


        audioSource.pitch = Mathf.Pow(pitchOctaveValue, (1 + (Random.Range(-pitchRange, +pitchRange))));

        audioSource.volume = Random.Range(minVolumeRange, maxVolumeRange);
        audioSource.Play();
    }

    private void disableRandomAudioSuccessively() {
        do {
            randomValueFromSoundArray = Random.Range(0, shootSounds.Length);
        }
        while (previousRandomValue == randomValueFromSoundArray);
        previousRandomValue = randomValueFromSoundArray;
    }
}