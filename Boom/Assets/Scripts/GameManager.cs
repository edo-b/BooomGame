using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public int coinsToWin = 5;
	public Text coinText;
	public int collectedCoins = 0;
	public bool isGameOver = false;
	public GameObject door;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		coinText.text = collectedCoins.ToString () + "/" + coinsToWin.ToString ();

		if (collectedCoins == coinsToWin) {
			door.SetActive(true);
		}
	}
}
