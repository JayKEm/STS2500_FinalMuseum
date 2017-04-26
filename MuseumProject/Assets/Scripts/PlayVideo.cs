using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour {

    public VideoPlayer vid;
    public AudioSource aud;
	// Use this for initialization
	void Start () {
        //((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Interact")) {
            if (aud.isPlaying) {
                aud.Pause();
                vid.Pause();
            } else {
                aud.Play();
                vid.Play();
            }
        }
    }
}
