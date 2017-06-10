using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public int coinsToWin = 5;
	public int collectedCoins = 0;
	public Text coinText;
	public Text gameOver;
	public GameObject player;
	public GameObject door;
	public GameObject gameOverCanvas;
	public bool isGameOver = false;

	// Use this for initialization
	void Start () {
		gameOverCanvas.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		coinText.text = collectedCoins.ToString () + "/" + coinsToWin.ToString ();

		if (!player) {
			gameOverCanvas.SetActive(true);
		}

		if (collectedCoins == coinsToWin) {
			door.SetActive(true);
		}
	}
}
