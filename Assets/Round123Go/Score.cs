using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    Text canvasText;
    int player1Score = 0;
    int player2Score = 0;

    GameObject otherScript;


    // Use this for initialization
    void Start() {
        //Debug.Log(gameObject.name);
        canvasText = GetComponent<Text>();
        player1Score = BoundaryDestroy.getPlayer1Score();
        player2Score = BoundaryDestroy.getPlayer2Score();
        if(gameObject.name.Equals("PlayerXWon")) {
            canvasText.text = "";
        }

    }

    // Update is called once per frame
    void Update() {
		if (gameObject.name.Equals ("ScorePlayer1")) {
			canvasText.text = "\n    " + player1Score;
		} else if (gameObject.name.Equals ("ScorePlayer2")) {
			canvasText.text = "\n" + player2Score + "    ";
		} else if (gameObject.name.Equals ("PlayerXWon")) {
			//Debug.Log("PlayerXWon");
		} else {
            Debug.Log("Fehler, ScorePlayerX nicht gefunden!");
        }

        //Player 1 Won  else if Player 2 Won
        if (BoundaryDestroy.getPlayer1Score() >= 3 && gameObject.name.Equals("PlayerXWon")) {
            canvasText.text = "Player 1 Won!!!";
        } else if (BoundaryDestroy.getPlayer2Score() >= 3 && gameObject.name.Equals("PlayerXWon")) {
            canvasText.text = "Player 2 Won!!!";
        }

    }
}
