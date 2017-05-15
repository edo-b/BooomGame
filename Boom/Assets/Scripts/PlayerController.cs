using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int speed = 10;
	public GameObject bomb;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var moveHorizontal = speed * Time.deltaTime * Input.GetAxis ("Horizontal");
		var moveVertical = speed * Time.deltaTime * Input.GetAxis ("Vertical");
		transform.position = transform.position + new Vector3 (moveHorizontal, 0, moveVertical);

		if (Input.GetKeyDown (KeyCode.Space)) {
			Instantiate(bomb, transform.position, Quaternion.identity);
		}
	}
}
