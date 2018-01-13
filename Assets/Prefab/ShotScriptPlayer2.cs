using UnityEngine;
using System.Collections;

public class ShotScriptPlayer2 : MonoBehaviour {
    public float speed;
    public float lifetime;
    public float upScale;

    public float shotPowerSnake = 0f;


    public AudioClip[] shootSoundsShort;
    public AudioClip[] shootSoundsMiddle;
    public AudioClip[] shootSoundsLong;

    [Range(0, 36f)]//Value below
    public float pitchRange = -36f;

    public float minVolumeRange = 0.8f;
    public float maxVolumeRange = 1f;


    private AudioSource audioSource;
    private int randomValueFromSoundArray;
    private static int previousRandomValue = -1;
    private float pitchOctaveValue = 1.05946f;

    private float firstSector = 1f;
    private float secondSector = 1.5f;


    void Start() {
        Rigidbody rb = (Rigidbody)GetComponent(typeof(Rigidbody));
        rb.velocity = transform.forward * speed + transform.up * upScale;

        audioSource = gameObject.GetComponent<AudioSource>();
        if (shootSoundsShort.Length > 0) {
            disableRandomAudioSuccessively();
            playRandomSoundOnStart();
        } else {
            Debug.Log("No SoundClips in Array!");
        }

        if (shotPowerSnake <= firstSector) {
            Debug.Log("short");
        } else if (shotPowerSnake <= secondSector) {
            Debug.Log("middle");
        } else if (shotPowerSnake > secondSector) {
            Debug.Log("long");
        }

    }

    void Awake() {
        Destroy(gameObject, lifetime);
    }

    void playRandomSoundOnStart() {
        audioSource.clip = shootSoundsShort[randomValueFromSoundArray];

        

        audioSource.pitch = Mathf.Pow(pitchOctaveValue, (1 + (Random.Range(-pitchRange, +pitchRange))));

        audioSource.volume = Random.Range(minVolumeRange, maxVolumeRange);

        audioSource.Play();

        //Debug.Log("you played: " + shootSounds[randomValueFromSoundArray]);


    }

    private void disableRandomAudioSuccessively() {
        do {
            randomValueFromSoundArray = Random.Range(0, shootSoundsShort.Length);
        }
        while (previousRandomValue == randomValueFromSoundArray);

        if (shootSoundsShort.Length == 1) {
            previousRandomValue = -1;
        } else {
            previousRandomValue = randomValueFromSoundArray;
        }

    }




}