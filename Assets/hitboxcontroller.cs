using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitboxcontroller : MonoBehaviour {

    private GameObject player;

    public int damege = 0;
    public float hitkoutyoku;
    
    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("player");
    }
	
	// Update is called once per frame
	void Update () {
 
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            player.GetComponent<playercontroller2>().hithantei();
            this.hitkoutyoku = player.GetComponent<playercontroller2>().hitkoutyoku;
        }
    }
}
