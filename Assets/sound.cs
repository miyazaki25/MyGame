using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour {

    public AudioSource audioSource;

    public AudioClip[] audioclip = new AudioClip[10];

    // Use this for initialization
    void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
