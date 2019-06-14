using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zako2contoroller : MonoBehaviour
{

    //アニメーションするためのコンポーネントを入れる
    private Animator myAnimator;

    float speed = 0.01f;
    public int HP = 30;
    public GameObject hitboxenemy;
    private GameObject player;
    private GameObject textcontroller;
    //攻撃サイクル
    private float cycle = 0;

    //硬直
    public float koutyoku;
    public float hitkoutyoku;
    public float cansel;
    public int combosu;

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
        //当たり判定を作成
        GameObject go = Instantiate(hitboxenemy) as GameObject;
        go.transform.position = new Vector2(this.transform.position.x + 1 * this.transform.localScale.x, this.transform.position.y);
        Destroy(go, 0.3f);
        //ダメージ
        go.GetComponent<hitboxenemycontroller>().damege = 1;

    }
    //フェイント関数
    public void feint()
    {
        koutyoku = 1f;

    }


    // Use this for initialization
    void Start()
    {
        HP = 30;
        player = GameObject.FindWithTag("player");
        textcontroller = GameObject.Find("textcontroller");

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "hitboxplayer")
        {
            HP -= other.GetComponent<hitboxcontroller>().damege;
            this.hitkoutyoku = other.GetComponent<hitboxcontroller>().hitkoutyoku;
        }
    }



    // Update is called once per frame
    void Update()
    {
        //プレイヤーとの距離
        float a = player.transform.position.x;
        float b = this.transform.position.x;
        float c = System.Math.Abs(a - b);


        if (koutyoku >= 0)
        {
            koutyoku -= Time.deltaTime;
        }
        if (hitkoutyoku >= 0)
        {
            hitkoutyoku -= Time.deltaTime;
        }
        if (koutyoku <= 0 && hitkoutyoku <= 0)
        {
            this.transform.position += new Vector3(speed * this.transform.localScale.x, 0, 0);
        }


        cycle += Time.deltaTime;
        if (cycle > 3 && hitkoutyoku <= 0 && koutyoku <= 0 && HP >= 0)
        {
            cycle = 0;
            int d = Random.Range(1, 6);
            if (c < 2)
            {
                if (d > 2)
                {
                    StartCoroutine("attack1");
                }
                else if (d == 2)
                {
                    feint();
                }
            }
            else if (2 <= c && c < 4)
            {
                if (d == 4)
                {

                }
                else if (d > 4)
                {
                    feint();
                }
            }
        }


        if (HP <= 0)
        {
            textcontroller.GetComponent<textcontroller>().scorekousin();
            Destroy(this.gameObject);
        }

    }
}
