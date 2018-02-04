using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_Spawner : MonoBehaviour {
	GameObject[] pipeUp = new GameObject[5];
	GameObject[] pipeDown = new GameObject[5];
	int[] offsets = { 1, 4, 3, 6, 3 };
	bool[] scored = { false, false, false, false, false };

	static bool prevState = Vive_player.inGame;
	static float speed = -10;
	static float pipeStart = -30;
	static float gap = 27;
	void placePipe(GameObject pipe, Vector3 pos){
		pipe.transform.localScale=new Vector3 (5, 10, 5);
		pipe.transform.position = pos;
	}


	// Use this for initialization
	void Start () {
		for (int i = 0; i < 5; i++) {
			Vive_player.score = 0;
			scored [i] = false;
			Destroy(pipeUp[i]);
			Destroy (pipeDown [i]);
			pipeDown [i] = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
			pipeUp [i] = GameObject.CreatePrimitive (PrimitiveType.Cylinder);

			placePipe (pipeDown [i], new Vector3(pipeStart*(i+1),offsets[i],0));
			placePipe (pipeUp [i], new Vector3(pipeStart*(i+1),gap+offsets[i],0));
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Vive_player.inGame) {
			for (int i = 0; i < 5; i++) {
			
				pipeUp [i].transform.position = pipeUp [i].transform.position + (new Vector3 (-1, 0, 0)) * speed * Time.deltaTime;
				pipeDown [i].transform.position = pipeDown [i].transform.position + (new Vector3 (-1, 0, 0)) * speed * Time.deltaTime;
		
				if (pipeUp [i].transform.position.x > 50) {
					Destroy (pipeUp [i]);
					scored [i] = false;
					pipeUp [i] = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
					offsets [i] = (int)Random.Range (0.0f, 20.0f);
					placePipe (pipeUp [i], new Vector3 (pipeStart * (5), gap + offsets [i], 0));

					Destroy (pipeDown [i]);
					pipeDown [i] = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
					placePipe (pipeDown [i], new Vector3 (pipeStart * (5), offsets [i], 0));
					Vive_player.score += 1;
				}
				if (pipeUp [i].transform.position.x > 0 && !scored [i]) {
					Vive_player.score += 1;
					scored [i] = true;
				}
			}
		}
		if (prevState != Vive_player.inGame && Vive_player.inGame) {
			Start ();
		}
		prevState = Vive_player.inGame;
	}
}
	