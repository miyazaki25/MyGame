using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitboxcontroller : MonoBehaviour {
    public GameObject hitboxprefab;
    // Use this for initialization
    public GameObject player;

    public GameObject hitboxclone;

    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {



        if (Input.GetKeyDown(KeyCode.Z))
        {
          
            GameObject go = Instantiate(hitboxprefab) as GameObject;
            go.transform.position = new Vector2(player.transform.position.x-0.7f, player.transform.position.y);
            hitboxclone = GameObject.Find("hitboxprefab(Clone)");
            Destroy(hitboxclone, 1.0f);


        }
 


    }
}
