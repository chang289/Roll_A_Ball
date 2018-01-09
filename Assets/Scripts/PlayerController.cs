using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

//	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}

	private Rigidbody rb;
	public Text countText;
	public Text winText;

	public float speed;
	private int count;

	void Start() {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		winText.text = "";
		setCountText ();
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
//		Destroy (other.gameObject);
		if (other.gameObject.CompareTag("Pick Up")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			setCountText ();
		}
	}

	void setCountText() {
		countText.text = "Count: " + count.ToString ();
		if (count >= 11) {
			winText.text = "You win!";
		}
	}
}
