using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class doragoncontoroller : MonoBehaviour
{

    //アニメーションするためのコンポーネントを入れる
    public Animator myAnimator;
    //プレイヤーを移動させるコンポーネントを入れる
    Rigidbody2D rigid2D;
    float speed = 0.01f;
    private int saidaiHP = 20;
    public int HP;
    public GameObject tamaenemy;
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
    private float ground = -0.4f;

    //攻撃地上１ 火の玉
    public IEnumerator attack1()
    {


        //硬直に代入
        koutyoku = 2f;



        //キャンセル可能時間
        cansel = 0.7f;
        //コンボ数をふやす
        combosu = 1;
        //アニメーション
        myAnimator.SetTrigger("attacktrigger");
        //SE
        soundsin.sound0(1);
        yield return new WaitForSeconds(0.2f);
        if (hidankoutyoku > 0)
        {
            yield break;
        }
        //当たり判定を作成
        GameObject go = Instantiate(tamaenemy) as GameObject;
        go.transform.position = new Vector2(this.transform.position.x + 1 * this.transform.localScale.x, this.transform.position.y - 1);
        go.transform.localScale = new Vector3(1.5f * this.gameObject.transform.localScale.x, 1.5f, 1);
        //ふっとび
        go.GetComponent<tamaenemycontoroller>().huttobix = 2;
        go.GetComponent<tamaenemycontoroller>().huttobiy = 2;
        go.GetComponent<tamaenemycontoroller>().muki = this.gameObject.transform.localScale.x;
        //ダメージ
        go.GetComponent<tamaenemycontoroller>().damege = 1;
        //ヒット時硬直差
        go.GetComponent<tamaenemycontoroller>().hitkoutyoku = 0.6f;
        Destroy(go, 3);

    }
    //攻撃地上１ キック
    public IEnumerator attack2()
    {


        //硬直に代入
        koutyoku = 1.6f;



        //キャンセル可能時間
        cansel = 0.7f;
        //コンボ数をふやす
        combosu = 1;
        //アニメーション
        myAnimator.SetTrigger("kicktrigger");
        //SE
        soundsin.sound0(1);
        //横方向に力をくわえる
        this.rigid2D.velocity = new Vector2(2 * this.gameObject.transform.localScale.x, 0);
        yield return new WaitForSeconds(0.2f);
        if (hidankoutyoku > 0)
        {
            yield break;
        }
        //当たり判定を作成
        GameObject go = Instantiate(hitboxenemy) as GameObject;
        go.transform.position = new Vector2(this.transform.position.x + 1 * this.transform.localScale.x, this.transform.position.y-1);
        go.transform.localScale = new Vector3(1.5f * this.gameObject.transform.localScale.x, 1.5f, 1);
        //ふっとび
        go.GetComponent<hitboxenemycontroller>().huttobix = 2;
        go.GetComponent<hitboxenemycontroller>().huttobiy = 2;
        //ダメージ
        go.GetComponent<hitboxenemycontroller>().damege = 1;
        //ヒット時硬直差
        go.GetComponent<hitboxenemycontroller>().hitkoutyoku = 0.6f;
        Destroy(go, 0.3f);

    }
    //攻撃地上 突進
    public IEnumerator attack3()
    {


        //硬直に代入
        koutyoku = 3f;



        //キャンセル可能時間
        cansel = 0.7f;
        //コンボ数をふやす
        combosu = 1;
        //アニメーション
        myAnimator.SetTrigger("striketrigger");
        //SE
        soundsin.sound0(1);
        //横方向に力をくわえる
        this.rigid2D.velocity = new Vector2(5 * this.gameObject.transform.localScale.x, 0);
        yield return new WaitForSeconds(0.2f);
        if (hidankoutyoku > 0)
        {
            yield break;
        }
        //当たり判定を作成
        GameObject go = Instantiate(hitboxenemy) as GameObject;
        go.transform.position = new Vector2(this.transform.position.x + 1 * this.transform.localScale.x, this.transform.position.y - 1);
        go.transform.localScale = new Vector3(1.5f * this.gameObject.transform.localScale.x, 1.5f, 1);
        //ふっとび
        go.GetComponent<hitboxenemycontroller>().huttobix = 2;
        go.GetComponent<hitboxenemycontroller>().huttobiy = 2;
        //ダメージ
        go.GetComponent<hitboxenemycontroller>().damege = 1;
        //ヒット時硬直差
        go.GetComponent<hitboxenemycontroller>().hitkoutyoku = 0.6f;
        Destroy(go, 0.5f);
        yield return null;
        if (go != null)
        {
            go.transform.position = new Vector2(this.transform.position.x + 1.2f * this.transform.localScale.x, this.transform.position.y - 1);
        }
        yield return null;
        if (go != null)
        {
            go.transform.position = new Vector2(this.transform.position.x + 1.5f * this.transform.localScale.x, this.transform.position.y - 1);
        }
        yield return null;
        if (go != null)
        {
            go.transform.position = new Vector2(this.transform.position.x + 1.6f * this.transform.localScale.x, this.transform.position.y - 1);
        }
        yield return null;
        if (go != null)
        {
            go.transform.position = new Vector2(this.transform.position.x + 1.7f * this.transform.localScale.x, this.transform.position.y - 1);
        }
        yield return null;
        if (go != null)
        {
            go.transform.position = new Vector2(this.transform.position.x + 2f * this.transform.localScale.x, this.transform.position.y - 1);
        }
        yield return null;
        if (go != null)
        {
            go.transform.position = new Vector2(this.transform.position.x + 2.2f * this.transform.localScale.x, this.transform.position.y - 1);
        }
        yield return null;
        if (go != null)
        {
            go.transform.position = new Vector2(this.transform.position.x + 2.3f * this.transform.localScale.x, this.transform.position.y - 1);
        }

    }
    //フェイント関数
    public void feint()
    {
        koutyoku = 1f;

    }
    

    // Use this for initialization
    void Start()
    {
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
           
            Debug.Log("敵ＨＰ" + HP + "被弾硬直" + hidankoutyoku);
            slider2.maxValue = saidaiHP;
            slider2.value = HP;
           
            //ふっとび
            if (other.GetComponent<hitboxcontroller>().damege >= 5)
            {
                this.rigid2D.velocity = new Vector2(other.GetComponent<hitboxcontroller>().futtobix * other.gameObject.transform.localScale.x, other.GetComponent<hitboxcontroller>().futtobiy);
                myAnimator.SetTrigger("hurttrigger");
                this.hidankoutyoku = other.GetComponent<hitboxcontroller>().hitkoutyoku;
            }
         

            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "tama")
        {

            HP -= other.GetComponent<tamacontoroller>().damege;
            this.hidankoutyoku = other.GetComponent<tamacontoroller>().hitkoutyoku;
            Debug.Log("敵ＨＰ" + HP);
            myAnimator.SetTrigger("hurttrigger");
            slider2.maxValue = saidaiHP;
            slider2.value = HP;
            Destroy(other.gameObject);

        }
    }



    // Update is called once per frame
    void Update()
    {

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
        if (hidankoutyoku >= 0)
        {
            hidankoutyoku -= Time.deltaTime;
        }
        if (koutyoku <= 0 && hidankoutyoku <= 0)
        {
            this.transform.position += new Vector3(speed * this.transform.localScale.x, 0, 0);
        }
        if(koutyoku >= 0)
        {
            myAnimator.SetBool("koutyokubool", true);

        }
        else
        {
            myAnimator.SetBool("koutyokubool", false);
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
        if (hidankoutyoku <= 0 && koutyoku <= 0 && HP > 0)
        {       //向き反転
            if (a - b > 0)
            {
                this.gameObject.transform.localScale = new Vector2(1, 1);
            }
            else if (a - b < 0)
            {
                this.gameObject.transform.localScale = new Vector2(-1, 1);
            }

            if (cycle > 3)
            {

                int d = Random.Range(1, 6);
                if (c < 3)
                {
                    if (d >= 6)
                    {
                        StartCoroutine("attack3");
                    }

                    else if (d >= 2)
                    {
                        StartCoroutine("attack2");
                    }
                    else if (d >= 1)
                    {
                        feint();
                    }
                }
                else if (3 <= c && c < 8)
                {
                    if (d >= 4)
                    {
                        StartCoroutine("attack1");
                    }
                    else if (d >= 2)
                    {
                        StartCoroutine("attack3");
                    }
                    else if (d >= 1)
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

            

        }
    }
}
