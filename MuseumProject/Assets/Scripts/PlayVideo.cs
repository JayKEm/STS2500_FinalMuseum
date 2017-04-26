using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour {

    bool inRange, grabbed;
    GameObject ghostAudio;
    public VideoPlayer vid;
    public AudioSource aud;
    Transform player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        if (inRange || grabbed) {
            if (Input.GetButtonDown("Grab")) {
                if (!grabbed) {
                    grabbed = true;
                    if (ghostAudio == null) {
                        ghostAudio = new GameObject(aud.clip.name);
                        AudioSource gA = ghostAudio.AddComponent<AudioSource>();
                        CopyClassValues<AudioSource>(aud, gA);
                        gA.clip = aud.clip;
                        gA.PlayScheduled(aud.time);
                        aud.Pause();

                        vid.Stop();
                        vid.Play();

                        Destroy(aud);
                        aud = gA;
                    }
                        ghostAudio.transform.position = player.position;
                        ghostAudio.transform.parent = player;
                } else {
                    grabbed = false;
                    ghostAudio.transform.parent = null;
                }
            }

            if ((grabbed&&!inRange)? Input.GetButtonDown("GrabPlay") :Input.GetButtonDown("Interact")) {
                if (vid.isPlaying) {
                    if (aud != null) aud.Pause();
                    vid.Pause();
                } else {
                    if (aud != null) aud.Play();
                    vid.Play();
                }
            }
        }
    }

    void OnTriggerEnter(Collider col) {
        //Debug.Log("Collided: "+ gameObject.name+" | "+col.gameObject.name);
        if (!col.gameObject.name.ToLower().Equals("playerinteract")) return;
        inRange = true;
    }

    void OnTriggerExit(Collider col) {
        //Debug.Log("Left: " + gameObject.name + " | " + col.gameObject.name);
        if (!col.gameObject.name.ToLower().Equals("playerinteract")) return;
        inRange = false;
    }

    public void CopyClassValues<T>(T sourceComp, T targetComp) where T: Component {
        FieldInfo[] sourceFields = sourceComp.GetType().GetFields(BindingFlags.Public |
                                                         BindingFlags.NonPublic |
                                                         BindingFlags.Instance);
        int i = 0;
        for (i = 0; i < sourceFields.Length; i++) {
            var value = sourceFields[i].GetValue(sourceComp);
            sourceFields[i].SetValue(targetComp, value);
        }
    }
}
