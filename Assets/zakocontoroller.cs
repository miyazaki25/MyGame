using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zakocontoroller : MonoBehaviour {

    //アニメーションするためのコンポーネントを入れる
    private Animator myAnimator;
    //プレイヤーを移動させるコンポーネントを入れる
    Rigidbody2D rigid2D;
    float speed = 0.01f;
    private int saidaiHP = 50;
    public int HP;
    public GameObject hitboxenemy;
    private GameObject player;
    private GameObject textcontroller;
    private Slider slider2;
    //攻撃サイクル
    private float cycle = 0;
    
    //硬直
    public float koutyoku;
    public float hidankoutyoku;
    public float cansel;
    public int combosu;

    //スコア反映
    private bool scorehanei = false;
   
    //攻撃地上１
    public IEnumerator attack1()
    {
     
       
        //硬直に代入
        koutyoku = 1.6f;



        //キャンセル可能時間
        cansel = 0.7f;
        //コンボ数をふやす
        combosu = 1;
        yield return new WaitForSeconds(0.5f);
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
        go.GetComponent<hitboxenemycontroller>().hitkoutyoku = 0.8f;
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



        }

        if (other.gameObject.tag == "tama")
        {

            HP -= other.GetComponent<tamacontoroller>().damege;
            this.hidankoutyoku = other.GetComponent<tamacontoroller>().hitkoutyoku;
            Debug.Log("敵ＨＰ" + HP);
            slider2.maxValue = saidaiHP;
            slider2.value = HP;
            Destroy(other.gameObject);

        }
    }



    // Update is called once per frame
    void Update () {
        //プレイヤーとの距離
        float a = player.transform.position.x;
        float b = this.transform.position.x;
        float c = System.Math.Abs(a - b);

        //向き反転
        if(a-b > 0)
        {
            this.gameObject.transform.localScale = new Vector2(1,1);
        }
        else if(a-b < 0)
        {
            this.gameObject.transform.localScale = new Vector2(-1, 1);
        }


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
       

        cycle += Time.deltaTime;
        if(cycle > 1 && hidankoutyoku <= 0)
        {
            cycle = 0;
            int d = Random.Range(1, 6);
             if (c < 2)
            {
                if(d > 2 )
                {
                    StartCoroutine("attack1");
                }
                else if(d == 2)
                {
                    feint();
                }
            }
             else if(2 <= c && c < 4)
            {
                if (d == 4 )
                {
                   StartCoroutine("attack1");
                }
                else if (d > 4 )
                {
                    feint();
                }
            }
        }


        if (HP <= 0 && !scorehanei)
        {
            textcontroller.GetComponent<textcontroller>().scorekousin();
            scorehanei = true;
            Destroy(this.gameObject, 1);
            
        }
    }
}
