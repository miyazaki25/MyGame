using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tamacontoroller : MonoBehaviour
{

    private GameObject player;
    //ＳＥ関係
    public int soundnuber;
    private static soundsingleton mInstance;
    soundsingleton soundsin;

    public int damege = 0;
    public float hitkoutyoku;
    public float muki = 0;
    public float futtobix = 0;
    public float futtobiy = 0;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("player");
        this.hitkoutyoku = player.GetComponent<playercontroller2>().hitkoutyoku;
        muki = player.gameObject.transform.localScale.x;
        Debug.Log("弾威力" + damege);
        //SE関係
        soundsin = soundsingleton.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0.08f * muki, 0, 0);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            player.GetComponent<playercontroller2>().hithantei();
            Destroy(this.gameObject);
            soundsin.sound0(soundnuber);
        }
    }
}
