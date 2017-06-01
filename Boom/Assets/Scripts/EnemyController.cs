using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public int moveSpeed;
	public int radius = 35;
	public bool isAlive = true;
	public GameObject player;
	public GameObject deathParticles;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isAlive == false) {
			Instantiate (deathParticles, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
		if (player != null && (Vector3.Distance(player.transform.position, transform.position) < radius)) {
			transform.LookAt(player.transform.position);
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Player") {
			Destroy(player);
		}
	}
}
