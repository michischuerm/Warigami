using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour {

    GameObject player1;
    GameObject player2;

    Text canvasText;

	public AudioClip japanSay1;
	public AudioClip japanSay2;
	public AudioClip japanSay3;

	 AudioSource audioSource;
	public float volumeSpeaker =1f;

	public float speed321 = 0.7f;

    // Use this for initialization
    void Start() {
        canvasText = GetComponent<Text>();

        TogglePlayerScripts(false);
        
		audioSource = GetComponent<AudioSource>();

        StartCoroutine(Count321());


    }

    IEnumerator Count321() {
		yield return new WaitForSeconds(speed321);
        canvasText.text = "3";
		audioSource.PlayOneShot (japanSay3, volumeSpeaker);
		yield return new WaitForSeconds(speed321);
        canvasText.text = "2";
		audioSource.PlayOneShot (japanSay2, volumeSpeaker);
		yield return new WaitForSeconds(speed321);
        canvasText.text = "1";
		audioSource.PlayOneShot (japanSay1, volumeSpeaker);
		yield return new WaitForSeconds(speed321);
        canvasText.text = "GO!!!";
        yield return new WaitForSeconds(0.5f);
        //ToDo: Fade In Fade Out
        //https://forum.unity.com/threads/fading-in-out-gui-text-with-c-solved.380822/
        canvasText.text = "";
        TogglePlayerScripts(true);
    }

    void TogglePlayerScripts(bool enablePlayerScripts) {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        //Enable player1 scripts
        player1.GetComponent<neweee>().enabled = enablePlayerScripts;
        player1.GetComponent<shots1337>().enabled = enablePlayerScripts;
        player1.GetComponent<XBoxPlayer1>().enabled = enablePlayerScripts;
        //Disable player2 scripts
        player2.GetComponent<test>().enabled = enablePlayerScripts;
        player2.GetComponent<shots1337_2>().enabled = enablePlayerScripts;
        player2.GetComponent<XBoxPlayer2>().enabled = enablePlayerScripts;

    }


    // Update is called once per frame
    void Update() {

    }
}
