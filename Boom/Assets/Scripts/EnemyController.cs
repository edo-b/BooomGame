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
		transform.LookAt(player.transform.position);
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
	}
}
