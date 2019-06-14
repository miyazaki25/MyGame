using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kakasicont : MonoBehaviour
{

    //アニメーションするためのコンポーネントを入れる
    public Animator myAnimator;
    //プレイヤーを移動させるコンポーネントを入れる
    Rigidbody2D rigid2D;

    public int HP;
    public GameObject hitboxenemy;
    private GameObject player;
    private GameObject textcontroller;

    //サウンド
    soundsingleton soundsin;
    //攻撃サイクル


    //硬直
    public float koutyoku;
    public float hidankoutyoku;
    public float cansel;
    public int combosu;





    // Use this for initialization
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
  
        player = GameObject.FindWithTag("player");
 

        //SE関係
        soundsin = soundsingleton.Instance;


    }

    //被弾時関数
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "hitboxplayer") { 
      

            Debug.Log("敵ＨＰ" + HP + "被弾硬直" + hidankoutyoku);
            Destroy(other.gameObject);
            //ふっとび

            myAnimator.SetTrigger("damagetrigger");



        }

        if (other.gameObject.tag == "tama")
        {

     
            Debug.Log("敵ＨＰ" + HP);
            myAnimator.SetTrigger("damagetrigger");
            Destroy(other.gameObject);

        }
    }



    // Update is called once per frame
    void Update()
    {

      
    }
}
