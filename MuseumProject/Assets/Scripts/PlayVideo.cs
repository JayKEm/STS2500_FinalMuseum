using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVideo : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {

            Renderer r = GetComponent<Renderer>();
            MovieTexture movie = (MovieTexture)r.material.mainTexture;

            if (movie.isPlaying)
            {
                movie.Pause();
            }
            else
            {
                movie.Play();
            }
        }
    }
}
