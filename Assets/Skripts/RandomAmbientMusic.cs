using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAmbientMusic : MonoBehaviour {


    public AudioClip[] ambientSounds;

    private AudioSource audioSource;
    private int randomValueFromSoundArray;
    private static int previousRandomValue = 0;


    // Use this for initialization
    void Start() {
        audioSource = gameObject.GetComponent<AudioSource>();
        disableRandomAudioSuccessively();
        playRandomSoundOnStart();

    }


    void playRandomSoundOnStart() {
        audioSource.clip = ambientSounds[randomValueFromSoundArray];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update() {

    }

    private void disableRandomAudioSuccessively() {
        do {
            randomValueFromSoundArray = Random.Range(0, ambientSounds.Length);
        }
        while (previousRandomValue == randomValueFromSoundArray);
        previousRandomValue = randomValueFromSoundArray;
    }
}
