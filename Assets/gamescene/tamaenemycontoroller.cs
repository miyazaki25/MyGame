using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tamaenemycontoroller : MonoBehaviour
{

    private GameObject doragon;
    //ＳＥ関係
    public int soundnuber;
    private static soundsingleton mInstance;
    soundsingleton soundsin;

    public GameObject particle;

    public int damege = 0;
    public float hitkoutyoku;
    public float muki = 0;
    public float mukiy = 0;
    public float huttobix = 0;
    public float huttobiy = 0;

    // Use this for initialization
    void Start()
    {
        Debug.Log("弾威力" + damege);
        //SE関係
        soundsin = soundsingleton.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0.08f * muki, mukiy, 0);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {
            other.GetComponent<playercontroller2>().hidan(damege, hitkoutyoku, huttobix, huttobiy);
            Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation);
            soundsin.sound0(2);
            Destroy(this.gameObject);
        }
    }
}
