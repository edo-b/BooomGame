using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public float currentTime = 0.0f;
	public int coinsToWin = 5;
	public int collectedCoins = 0;
	public int speed = 50;
	public Text coinText;
	public Text timeText;
	public GameObject player;
	public GameObject portal;
	public GameObject gameOverCanvas;
	public bool isGameOver = false;
	public bool record = true;

	// Use this for initialization
	void Start () {
		gameOverCanvas.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (record) {
			currentTime += Time.deltaTime;
			timeText.text = currentTime.ToString ("0.0");
		}
		coinText.text = collectedCoins.ToString () + "/" + coinsToWin.ToString ();

		if (!player) {
			record = false;
			gameOverCanvas.SetActive(true);
			timeText.text = currentTime.ToString("0.0");
		}

		if (collectedCoins == coinsToWin) {
			record = false;
			portal.SetActive(true);
			portal.transform.Rotate(Vector3.right * speed * Time.deltaTime);
			timeText.text = currentTime.ToString("0.0");
		}
	}
}
