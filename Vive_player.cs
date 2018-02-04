using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vive_player : MonoBehaviour {
	public static bool inGame = false;
	public Transform cameraRigTransform;
	public static int score = 0;
	public GameObject textObject;
	public TextMesh startText;

	void Start(){
		startText = textObject.GetComponent<TextMesh> ();
		startText.text = "FlapVR\nPress trigger to Start \nScore: " + score;
	}
	void OnTriggerEnter (Collider other)
	{
		inGame = false;
		Debug.Log ("Collision");
	}
	// Update is called once per frame
	void Update () {
		if (!inGame) {
			this.GetComponent<Rigidbody> ().useGravity = false;
			cameraRigTransform.position = new Vector3 (0, 10, 0);
			startText.text = "FlapVR\nPress trigger to Start \nScore: " + score;
		} else {
			this.GetComponent<Rigidbody> ().useGravity = true;
			startText.text = "Score: " + score;
		}

	}
}
