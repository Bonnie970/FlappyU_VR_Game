using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vive_Controller : MonoBehaviour {
	private int flapCount = 0;
	public Transform cameraRigTransform;
	AudioSource wing;
	// 1
	private SteamVR_TrackedObject trackedObj;
	// 2
	private SteamVR_Controller.Device Controller
	{
		get { return SteamVR_Controller.Input((int)trackedObj.index); }
	}
	void Flap(){
		Vector3 position = cameraRigTransform.position;
		position.y = (float)0.4;
		position.x = 0;
		position.z = 0;
		cameraRigTransform.position = cameraRigTransform.position + position;

		wing.Play ();

	}
	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
		wing = GetComponent<AudioSource>();
	}
	// Update is called once per frame
	void Update () {
		if (Controller.velocity [1] < -1) {
			flapCount += 1;
			if (Vive_player.inGame == true) {
				Flap ();
			}
		}
		if (Controller.GetHairTriggerDown ()) {
			Vive_player.inGame = true;
		}
		//Debug.Log(gameObject.name + Controller.velocity[1]);
	}
}
