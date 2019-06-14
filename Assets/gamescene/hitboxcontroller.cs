using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitboxcontroller : MonoBehaviour {

    private GameObject player;
    private static soundsingleton mInstance;
    soundsingleton soundsin;
    public GameObject particle;

    public int damege = 0;
    public float hitkoutyoku;
    public float futtobix = 0;
    public float futtobiy = 0;

    //ＳＥ関係
    public int soundnuber;

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("player");
        if(player != null)
        {
            this.hitkoutyoku = player.GetComponent<playercontroller2>().hitkoutyoku;
        }
       
        //SE関係
        soundsin = soundsingleton.Instance;

    }
	
	// Update is called once per frame
	void Update () {

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            player.GetComponent<playercontroller2>().hithantei();
            Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation);
            soundsin.sound0(soundnuber);

        }
    }
}
