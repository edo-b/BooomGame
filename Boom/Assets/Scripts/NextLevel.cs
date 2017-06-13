using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	public string levelLoad;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadLevel () {
		Application.LoadLevel (levelLoad);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			Invoke ("LoadLevel", 2);
		}
	}
}
