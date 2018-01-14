using UnityEngine;
using System.Collections;

public class ShotScriptPlayer2 : MonoBehaviour {
    public float speed;
    public float lifetime;
    public float upScale;

    public float shotPowerSnake = 0f;

    private AudioClip[] shootSoundsCurrent;
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

        if (shotPowerSnake <= firstSector) {
            shootSoundsCurrent = shootSoundsShort;
            //Debug.Log("short");
        } else if (shotPowerSnake <= secondSector) {
            shootSoundsCurrent = shootSoundsMiddle;
            //Debug.Log("middle");
        } else if (shotPowerSnake > secondSector) {
            shootSoundsCurrent = shootSoundsLong;
            //Debug.Log("long");
        }
        if (shootSoundsShort.Length > 0) {
            disableRandomAudioSuccessively(shootSoundsCurrent);
            playRandomSoundOnStart(shootSoundsCurrent);
        } else {
            Debug.Log("No SoundClips in Array!");
        }
    }

    void Awake() {
        Destroy(gameObject, lifetime);
    }

    private void disableRandomAudioSuccessively(AudioClip[] shootArrayDependingOnShotPower) {
        do {
            randomValueFromSoundArray = Random.Range(0, shootArrayDependingOnShotPower.Length);
        }
        while (previousRandomValue == randomValueFromSoundArray);

        if (shootArrayDependingOnShotPower.Length == 1) {
            previousRandomValue = -1;
        } else {
            previousRandomValue = randomValueFromSoundArray;
        }

    }

    void playRandomSoundOnStart(AudioClip[] shootArrayDependingOnShotPower) {
        audioSource.clip = shootArrayDependingOnShotPower[randomValueFromSoundArray];
        audioSource.pitch = Mathf.Pow(pitchOctaveValue, (1 + (Random.Range(-pitchRange, +pitchRange))));
        audioSource.volume = Random.Range(minVolumeRange, maxVolumeRange);
        audioSource.Play();
        Debug.Log("you played: " + shootArrayDependingOnShotPower[randomValueFromSoundArray]);
    }
}