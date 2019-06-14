using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonzaihantei : MonoBehaviour {

    public GameObject player;
    private bool zimen;
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player.GetComponent<playercontroller2>().isGround)
        {
            this.gameObject.layer = LayerMask.NameToLayer("sonzaip");
        }
        else
        {
            this.gameObject.layer = LayerMask.NameToLayer("air");
        }
        
    }
}
