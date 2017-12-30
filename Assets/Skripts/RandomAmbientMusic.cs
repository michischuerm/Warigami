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
        playRandomSoundOnStart();

    }


    void playRandomSoundOnStart() {
        audioSource.clip = ambientSounds[randomValueFromSoundArray];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update() {

    }
}
