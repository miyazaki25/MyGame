using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitboxcontroller : MonoBehaviour {

    private GameObject player;

    public int damege = 0;
    public float hitkoutyoku;
    public float futtobix = 0;
    public float futtobiy = 0;

    //ＳＥ関係
    public AudioSource audioSource;
    public AudioClip sound;

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("player");
        this.hitkoutyoku = player.GetComponent<playercontroller2>().hitkoutyoku;
        Debug.Log(hitkoutyoku);
    }
	
	// Update is called once per frame
	void Update () {

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            player.GetComponent<playercontroller2>().hithantei();
            audioSource.Play();

        }
    }
}
