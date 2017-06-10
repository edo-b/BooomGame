using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public int moveSpeed;
	public int radius = 35;
	public bool isAlive = true;
	public GameObject player;
	public GameObject deathParticles;
	public GameObject coin;
	public bool isPlayerInRadius = false;

	// Use this for initialization
	void Start () {
		Vector3[] directions = {new Vector3 (0, 0, 0), new Vector3 (0, 90, 0), new Vector3 (0, 180, 0), new Vector3 (0, 270, 0)};
		transform.rotation = Quaternion.Euler (directions [Random.Range (0, 4)]);
	}
	
	// Update is called once per frame
	void Update () {
		if (isAlive == false) {
			Instantiate (deathParticles, transform.position, Quaternion.identity);
			Instantiate (coin, transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
			Destroy(gameObject);
		}
		if (player != null && (Vector3.Distance (player.transform.position, transform.position) < radius)) {
			transform.LookAt (player.transform.position);
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
			isPlayerInRadius = true;
		}
		//Walk randomly
		else {
			if(isPlayerInRadius){
				//This means that enemy just exited the radius and can be turned to any direction. We want to move it to
				//direction of 0, 90, 180 or 270 deg.
				if(transform.rotation.eulerAngles.y <= 45 && transform.rotation.eulerAngles.y > 315){
					transform.rotation = Quaternion.Euler(0, 0, 0);
				}
				else if(transform.rotation.eulerAngles.y > 45 && transform.rotation.eulerAngles.y <= 135){
					transform.rotation = Quaternion.Euler(0, 90, 0);
				}
				else if(transform.rotation.eulerAngles.y > 135 && transform.rotation.eulerAngles.y <= 225){
					transform.rotation = Quaternion.Euler(0, 180, 0);
				}
				else if(transform.rotation.eulerAngles.y > 225 && transform.rotation.eulerAngles.y <= 315){
					transform.rotation = Quaternion.Euler(0, 270, 0);
				}
				isPlayerInRadius = false;
			}
			//Check if enemy is stuck walking into a wall
			RaycastHit hit;
			if(Physics.Raycast (transform.position, transform.forward, out hit)){
				if(hit.distance <= 6 && (hit.transform.gameObject.tag == "Block" || hit.transform.gameObject.tag == "Wall" || hit.transform.gameObject.tag == "Enemy")){
					transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, randomSign()*90, 0));
				}
			}

			//Move forward
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<PlayerController> ().isAlive = false;
		}
		/*else if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Block") {
			if(!isPlayerInRadius){
				transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, randomSign()*90, 0));
			}
		}*/
	}

	private int randomSign() {
		if (Random.Range(0, 2) == 0) {
			return -1;
		}
		return 1;
	}
}
