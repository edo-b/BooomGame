using UnityEngine;
using System.Collections;
using System;

public class BombController : MonoBehaviour {
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		Invoke ("Explode", 3);
		Destroy (gameObject, 3);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void Explode(){
		RaycastHit hit;
		int expLimit = 0;
		if (Physics.Raycast (transform.position, Vector3.right, out hit)) {
			expLimit = Math.Min((int)hit.distance / 5, 5);
		}
		for (int i= 0; i < expLimit; i++) {
			Instantiate (explosion, transform.position + 5*i*Vector3.right, Quaternion.identity);
		}
		if (Physics.Raycast (transform.position, -Vector3.right, out hit)) {
			expLimit = Math.Min((int)hit.distance / 5, 5);
		}
		for (int i= 0; i < expLimit; i++) {
			Instantiate (explosion, transform.position -5*i*Vector3.right, Quaternion.identity);
		}
		if (Physics.Raycast (transform.position, Vector3.forward, out hit)) {
			expLimit = Math.Min((int)hit.distance / 5, 5);
		}
		for (int i= 0; i < expLimit; i++) {
			Instantiate (explosion, transform.position + 5*i*Vector3.forward, Quaternion.identity);
		}
		if (Physics.Raycast (transform.position, -Vector3.forward, out hit)) {
			expLimit = Math.Min((int)hit.distance / 5, 5);
		}
		for (int i= 0; i < expLimit; i++) {
			Instantiate (explosion, transform.position -5*i*Vector3.forward, Quaternion.identity);
		}

		//Raycast to find character to kill
		
		if (Physics.Raycast(transform.position, Vector3.right, out hit)) {
			if(hit.distance <= 20){
				if(hit.transform.gameObject.tag == "Player"){
					hit.transform.gameObject.GetComponent<PlayerController>().isAlive = false;
				}
				if(hit.transform.gameObject.tag == "Enemy"){
					hit.transform.gameObject.GetComponent<EnemyController>().isAlive = false;
				}
			}
		}
		if (Physics.Raycast(transform.position, -Vector3.right, out hit)) {
			if(hit.distance <= 20){
				if(hit.transform.gameObject.tag == "Player"){
					hit.transform.gameObject.GetComponent<PlayerController>().isAlive = false;
				}
				if(hit.transform.gameObject.tag == "Enemy"){
					hit.transform.gameObject.GetComponent<EnemyController>().isAlive = false;
				}
			}
		}
		if (Physics.Raycast(transform.position, Vector3.forward, out hit)) {
			if(hit.distance <= 20){
				if(hit.transform.gameObject.tag == "Player"){
					hit.transform.gameObject.GetComponent<PlayerController>().isAlive = false;
				}
				if(hit.transform.gameObject.tag == "Enemy"){
					hit.transform.gameObject.GetComponent<EnemyController>().isAlive = false;
				}
			}
		}
		if (Physics.Raycast(transform.position, -Vector3.forward, out hit)) {
			if(hit.distance <= 20){
				if(hit.transform.gameObject.tag == "Player"){
					hit.transform.gameObject.GetComponent<PlayerController>().isAlive = false;
				}
				if(hit.transform.gameObject.tag == "Enemy"){
					hit.transform.gameObject.GetComponent<EnemyController>().isAlive = false;
				}
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player") {
			GetComponent<Collider>().isTrigger = false;
		}
	}
}
