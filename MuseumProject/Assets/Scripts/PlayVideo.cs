using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour {

    bool inRange;

    public VideoPlayer vid;
    public AudioSource aud;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Interact") && inRange) {
            if (vid.isPlaying) {
                if (aud != null) aud.Pause();
                vid.Pause();
            } else {
                if (aud != null) aud.Play();
                vid.Play();
            }
        }
    }

    void OnTriggerEnter(Collider col) {
        inRange = true;
    }

    void OnTriggerExit(Collider col) {
        inRange = false;
    }
}
