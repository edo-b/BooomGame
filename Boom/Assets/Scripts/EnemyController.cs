using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public int moveSpeed;
	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) {
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
