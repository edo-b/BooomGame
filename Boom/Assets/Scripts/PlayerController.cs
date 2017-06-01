using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int speed = 10;
	public float rotationSpeed = 2f;
	public bool isAlive = true;
	public GameObject bomb;
	public GameObject deathParticles;
	public GameObject gameManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isAlive == false) {
			Instantiate (deathParticles, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
		var moveHorizontal = speed * Time.deltaTime * Input.GetAxis ("Horizontal");
		var moveVertical = speed * Time.deltaTime * Input.GetAxis ("Vertical");
		if (moveHorizontal > 0) {
			transform.rotation = Quaternion.Euler(0, 90, 0);
		}
		else if (moveHorizontal < 0) {
			transform.rotation = Quaternion.Euler(0, 270, 0);
		}
		if (moveVertical > 0) {
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		else if (moveVertical < 0) {
			transform.rotation = Quaternion.Euler(0, 180, 0);
		}
		transform.position = transform.position + new Vector3 (moveHorizontal, 0, moveVertical);

		if (Input.GetKeyDown (KeyCode.Space)) {
			Instantiate(bomb, transform.position, Quaternion.identity);
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Coin") {
			gameManager.GetComponent<GameManager>().collectedCoins++;
			Destroy(other.gameObject);
		}

		if (other.gameObject.tag == "Door") {
			gameManager.GetComponent<GameManager>().isGameOver = true;
		}
	}
}
