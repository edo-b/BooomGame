using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {

	public int speed = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.right * speed * Time.deltaTime);
	}
}
