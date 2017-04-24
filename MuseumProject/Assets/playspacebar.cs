using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playspacebar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Jump")) {

			Renderer r = GetComponent<Renderer>();
			MovieTexture movie = (MovieTexture)r.material.mainTexture;

			if (movie.isPlaying) {
				movie.Pause();
			//	audio.Pause();
			}
			else {
				movie.Play();
				//audio.Pause();
			}
		}
	}
}
