using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zakocontoroller : MonoBehaviour {

    //アニメーションするためのコンポーネントを入れる
    public Animator myAnimator;
    //プレイヤーを移動させるコンポーネントを入れる
    Rigidbody2D rigid2D;
    float speed = 0.01f;
    private int saidaiHP = 3;
    public int HP;
    public GameObject hitboxenemy;
    private GameObject player;
    private GameObject textcontroller;
    private Slider slider2;
    //サウンド
    soundsingleton soundsin;
    //攻撃サイクル
    private float cycle = 0;
    
    //硬直
    public float koutyoku;
    public float hidankoutyoku;
    public float cansel;
    public int combosu;

    //スコア反映
    private bool scorehanei = false;

    //地面判定
    public bool isGround;
    private float ground = -1.7f;

    //存在判定敵同士
    public GameObject sonzaihantei;
    public GameObject sonzaihanteiteki;


    //攻撃地上１
    public IEnumerator attack1()
    {
     
       
        //硬直に代入
        koutyoku = 1.6f;



        //キャンセル可能時間
        cansel = 0.7f;
        //コンボ数をふやす
        combosu = 1;
        //アニメーション
        myAnimator.SetTrigger("attcktrigger");
        //SE
        soundsin.sound0(1);
        yield return new WaitForSeconds(0.2f);
        if (hidankoutyoku > 0)
        {
            yield break;
        }
        //当たり判定を作成
        GameObject go = Instantiate(hitboxenemy) as GameObject;
        go.transform.position = new Vector2(this.transform.position.x + 1 * this.transform.localScale.x, this.transform.position.y);
        go.transform.localScale = new Vector3(0.7f * this.gameObject.transform.localScale.x, 0.5f, 1);
        //ふっとび
        go.GetComponent<hitboxenemycontroller>().huttobix = 2;
        go.GetComponent<hitboxenemycontroller>().huttobiy = 2;
        //ダメージ
        go.GetComponent<hitboxenemycontroller>().damege = 1;
        //ヒット時硬直差
        go.GetComponent<hitboxenemycontroller>().hitkoutyoku = 0.6f;
        Destroy(go, 0.3f);
       
    }
    //フェイント関数
    public void feint()
    {
        koutyoku = 1f;

    }


    // Use this for initialization
    void Start () {
        this.rigid2D = GetComponent<Rigidbody2D>();
        HP = saidaiHP;
        player = GameObject.FindWithTag("player");
        textcontroller = GameObject.Find("textcontroller");
        slider2 = GameObject.Find("Slider2").GetComponent<Slider>();
        //SE関係
        soundsin = soundsingleton.Instance;


    }

    //被弾時関数
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "hitboxplayer")
        {
            //ダメージ
                HP -= other.GetComponent<hitboxcontroller>().damege;
                this.hidankoutyoku = other.GetComponent<hitboxcontroller>().hitkoutyoku;
                Debug.Log("敵ＨＰ" + HP+ "被弾硬直" + hidankoutyoku);
                slider2.maxValue = saidaiHP;
                slider2.value = HP;
                Destroy(other.gameObject);
            //ふっとび
            this.rigid2D.velocity = new Vector2(other.GetComponent<hitboxcontroller>().futtobix * other.gameObject.transform.localScale.x, other.GetComponent<hitboxcontroller>().futtobiy);
            myAnimator.SetTrigger("damagetrigger");



        }

        if (other.gameObject.tag == "tama")
        {

            HP -= other.GetComponent<tamacontoroller>().damege;
            this.hidankoutyoku = other.GetComponent<tamacontoroller>().hitkoutyoku;
            Debug.Log("敵ＨＰ" + HP);
            myAnimator.SetTrigger("damagetrigger");
            slider2.maxValue = saidaiHP;
            slider2.value = HP;
            Destroy(other.gameObject);

        }
    }

    



        // Update is called once per frame
        void Update () {

        //地面判定
        isGround = (this.transform.position.y > this.ground) ? false : true;
        //地面による制御
        if (isGround)
        {
            myAnimator.SetBool("groundbool", true);

        }
        else
        {
            myAnimator.SetBool("groundbool", false);
        }


        //プレイヤーとの距離
        float a = player.transform.position.x;
        float b = this.transform.position.x;
        float c = System.Math.Abs(a - b);

 

        if (koutyoku >= 0)
        {
            koutyoku -= Time.deltaTime;
        }
        if(hidankoutyoku >= 0)
        {
            hidankoutyoku -= Time.deltaTime;
        }
        if (koutyoku <= 0 && hidankoutyoku <=0)
        {
            this.transform.position += new Vector3(speed * this.transform.localScale.x, 0, 0);
        }

        if (hidankoutyoku >= 0)
        {
            myAnimator.SetBool("hidankoutyokubool", true);

        }
        else
        {
            myAnimator.SetBool("hidankoutyokubool", false);
        }

        cycle += Time.deltaTime;
        if (hidankoutyoku <= 0 && koutyoku <= 0 && HP > 0 )
        {       //向き反転
            if (a - b > 0)
            {
                this.gameObject.transform.localScale = new Vector2(1, 1);
            }
            else if (a - b < 0)
            {
                this.gameObject.transform.localScale = new Vector2(-1, 1);
            }
          
            if (cycle > 2 )
            {
                int d = Random.Range(1, 6);
                if (c < 2)
                {
                    if (d > 0)
                    {
                        StartCoroutine("attack1");
                    }
                    else if (d == 1)
                    {
                        feint();
                    }
                }
                else if (2 <= c && c < 4)
                {
                    if (d == 4)
                    {
                        StartCoroutine("attack1");
                    }
                    else if (d > 4)
                    {
                        feint();
                    }
                }
                cycle = 0;
            }   
    
        }


        if (HP <= 0 && !scorehanei)
        {
            textcontroller.GetComponent<textcontroller>().scorekousin();
            scorehanei = true;
            myAnimator.SetBool("downbool", true);
         
            sonzaihantei.gameObject.layer = 15;
            sonzaihanteiteki.gameObject.layer = 15;


            this.gameObject.GetComponentInChildren<tamesi>().layermodosi();

            Destroy(this.gameObject, 1.5f);
            
        }
    }
}
