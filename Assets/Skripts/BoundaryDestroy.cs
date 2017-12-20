using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoundaryDestroy : MonoBehaviour {

	private static int player1Score = 0;
	private static int player2Score = 0;
	private bool dead = false;
	public int timeToRestartScene;
	public int timeToUI;

	public ParticleSystem particleExplosion;




	void OnTriggerEnter(Collider col) {
		if (col.gameObject.CompareTag("Player1") || col.gameObject.CompareTag("Player2")) {
			ParticleExplosion(col.gameObject.transform.position);
		}
		if (col.gameObject.CompareTag("Player1") && !dead) {
			Debug.Log("Player1 Destroyed!");
			setSceneDependingOnWinningPlayer(ref player2Score);

		} else if (col.gameObject.CompareTag("Player2") && !dead) {
			Debug.Log("Player2 Destroyed!");
			setSceneDependingOnWinningPlayer(ref player1Score);
		}
		Destroy(col.gameObject);
	}

	IEnumerator ExecuteAfterSeconds() {
		yield return new WaitForSeconds(timeToRestartScene);
		dead = false;
		Debug.Log("Player 1 Wins: " + player1Score);
		Debug.Log("Player 2 Wins: " + player2Score);
		SceneManager.LoadScene("FlaecheBrechen2_1");

	}
	IEnumerator StartUI() {
		yield return new WaitForSeconds(timeToUI);
		dead = false;
		Debug.Log("Player 1 Wins: " + player1Score);
		Debug.Log("Player 2 Wins: " + player2Score);
		player1Score = 0;
		player2Score = 0;
		SceneManager.LoadScene("UI New");

	}

	private void setSceneDependingOnWinningPlayer(ref int player) {
		player += 1;
		dead = true;
		if (player == 3) {
			StartCoroutine(StartUI());
		} else {
			StartCoroutine(ExecuteAfterSeconds());
		}
	}


	public void ParticleExplosion(Vector3 position) {
		Quaternion rotation = Quaternion.Euler(-90, 0, 0);
		Instantiate(particleExplosion, position, rotation);
		//Instantiate(particleExplosion, position, Quaternion.identity);
		//Instantiate(particleExplosion, position + (new Vector3(0, 8, 0)), Quaternion.identity); //offset
	}

	public static int getPlayer1Score() {
		return player1Score;
	}

	public static int getPlayer2Score() {
		return player2Score;
	}
}