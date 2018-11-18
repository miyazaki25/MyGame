using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller2 : MonoBehaviour {
    //HP
    public int HP = 2;
    
    
    //アニメーションするためのコンポーネントを入れる
    private Animator myAnimator;

    //移動速度
    private float speed = 0.01f;
    //ジャンプパワー
    private float jumppow = 10f;
    //プレイヤーを移動させるコンポーネントを入れる
    Rigidbody2D rigid2D;
    //硬直
    public float koutyoku;

    //空中硬直
    public float koutyokuair;

    //空中ワザ
    bool wazaair;

    //地面判定
    private bool isGround;

    //死亡判定
    private bool dead = false;

    //地面
    private float ground = -3.65f;

    //攻撃関係
    public GameObject hitbox;
    public int hitsu;
    public float cansel = 0;
    int combosu;

    public bool hit;



    //攻撃関数\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    //攻撃ヒット時に呼び出す関数
    public void hithantei()
    {
        hit = true;
    }


 
    //攻撃地上１
    public IEnumerator attack1()
    {

        yield return new WaitForSeconds(0.2f);
        //当たり判定を作成
        GameObject go = Instantiate(hitbox) as GameObject;
       　go.transform.position = new Vector2(this.transform.position.x + 1 * this.transform.localScale.x, this.transform.position.y);
        Destroy(go, 0.3f);
        //ダメージ
        go.GetComponent<hitboxcontroller>().damege = 1;
  
    }
    //攻撃時向き変更、硬直、キャンセル、コンボ数
    public void muki1(int muku)
    {      //向きを変更
       　Vector2 temp = gameObject.transform.localScale;
        temp.x = muku;
        gameObject.transform.localScale = temp;

        //硬直に代入
        koutyoku = 1.4f;

        //キャンセル可能時間
        cansel = 0.7f;
        //コンボ数をふやす
        combosu = 1;
        myAnimator.SetTrigger("atacktrriger");
      
    }

    //攻撃地上２
    public IEnumerator attack2()
    {


        //当たり判定を作成
        yield return new WaitForSeconds(0.2f);
        GameObject go = Instantiate(hitbox) as GameObject;
        go.transform.position = new Vector2(this.transform.position.x + 1 * this.transform.localScale.x, this.transform.position.y);
        Destroy(go, 0.6f);
        go.GetComponent<hitboxcontroller>().damege = 1;

    }
    //攻撃時向き変更、硬直、キャンセル、コンボ数
    public void muki2(int muku)
    {      //向きを変更
       　Vector2 temp = gameObject.transform.localScale;
        temp.x = muku;
        gameObject.transform.localScale = temp;
        //硬直に代入
        koutyoku = 1.2f;

        //キャンセル可能時間
        cansel = 0.7f;

        //コンボ数をふやす
        combosu = 2;

        myAnimator.SetTrigger("atacktrriger");

    }

    //空中攻撃1
    public IEnumerator attackair1()
    {


        //当たり判定を作成
        yield return new WaitForSeconds(0.2f);
        GameObject go = Instantiate(hitbox) as GameObject;
        go.transform.position = new Vector2(this.transform.position.x + 1 * this.transform.localScale.x , this.transform.position.y);
        Destroy(go, 0.8f);
        go.GetComponent<hitboxcontroller>().damege = 1;

    }
    public void mukiair1(int muku)
    {     
        //向きを変更
       　Vector2 temp = gameObject.transform.localScale;
        temp.x = muku;
        gameObject.transform.localScale = temp;
        //硬直に代入
        koutyokuair = 1.2f;

        //キャンセル可能時間
        cansel = 0.7f;

        //コンボ数をふやす
        combosu = 1;

        myAnimator.SetTrigger("jumpattacktrriger");

        //空中攻撃判定
        wazaair = true;
    }
    //空中攻撃2
    public IEnumerator attackair2()
    {


        //当たり判定を作成
        yield return new WaitForSeconds(0.25f);
        GameObject go = Instantiate(hitbox) as GameObject;
        go.transform.position = new Vector2(this.transform.position.x + 1 * this.transform.localScale.x, this.transform.position.y);
        Destroy(go, 0.6f);
        go.GetComponent<hitboxcontroller>().damege = 1;
    }
    public void mukiair2(int muku)
    {    
        //向きを変更
       　Vector2 temp = gameObject.transform.localScale;
        temp.x = muku;
        gameObject.transform.localScale = temp;
        //硬直に代入
        koutyokuair = 1.2f;

        //キャンセル可能時間
        cansel = 0.7f;

        //コンボ数をふやす
        combosu = 2;

        myAnimator.SetTrigger("jumpattacktrriger");

        //空中攻撃判定
        wazaair = true;
    }


    //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    //ジャンプ関数
    void jump(int muki)
    {

            //localScaleを変数に格納
            Vector2 temp = gameObject.transform.localScale;
            //localScale.xをmukiにする
            temp.x = muki;
            //結果を戻す
            gameObject.transform.localScale = temp;
            myAnimator.SetTrigger("jumptrriger");

            //上方向に力をくわえる
            this.rigid2D.velocity = new Vector2(0, this.jumppow);
       
    }
    //左右を向く関数
    void turn(int muki)
    {
            //localScaleを変数に格納
            Vector2 temp = gameObject.transform.localScale;
            //localScale.xを-2にする
            temp.x = muki;
            //結果を戻す
            gameObject.transform.localScale = temp;
        
    }

    //被弾関数
    public void hidan(int a)
    {
        HP -= a;
        Debug.Log("残りＨＰ" + HP.ToString());

    }
    


    
    
    
    
    // Use this for initialization
    void Start () {


        this.myAnimator = GetComponent<Animator>();
        this.rigid2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

     
  
        //地面判定
        isGround = (this.transform.position.y > this.ground) ? false : true;
        //アニメーションのための制御
        if (isGround)
        {
            myAnimator.SetBool("groundbool", true);

        }
        else
        {
            myAnimator.SetBool("groundbool", false);

        }
        //硬直を減らす
        if (koutyoku >= 0)
        {
            this.koutyoku -= Time.deltaTime;

        }

        //空中硬直を減らす
        if (koutyokuair >= 0)
        {
            this.koutyokuair -= Time.deltaTime;

        }
        //空中ワザ判定をリセット
        if (isGround && wazaair == true)
        {
            wazaair = false;
        }


        //キャンセルを減らす
        if (cansel >= 0)
        {
            this.cansel -= Time.deltaTime;
        }
      
        //コンボ数をリセット
        if (koutyoku <= 0 && combosu > 0)
        {
            combosu = 0;
        }

 
 
        //ヒットをリセット
        if (koutyoku <= 0 && hit)
        {
            hit = false;
        }

        //攻撃実行\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        //地上攻撃1 Z
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (koutyoku <= 0 && isGround && combosu == 0)
            {


                StartCoroutine("attack1");
                muki1(-1);
  
            }
            else if (cansel >= 0 && isGround && combosu == 1 && hit)
            {
                StartCoroutine("attack2"); 
                muki2(-1);
             
            }



        }


        //地上攻撃1 C
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (koutyoku <= 0 && isGround && combosu == 0)
            {

                StartCoroutine("attack1");
                muki1(1);
               
            }
            //地上攻撃２
            else if (cansel >= 0 && isGround && combosu == 1 && hit)
            {
                StartCoroutine("attack2");
                muki2(1);
               
            }
        }
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        //空中攻撃1 Z
        if (Input.GetKeyDown(KeyCode.Z) && koutyokuair <= 0 && !isGround && combosu == 0  && !wazaair)

        {


            StartCoroutine("attackair1");
            mukiair1(-1);
        

        }
        if (Input.GetKeyDown(KeyCode.Z) && cansel >= 0 && !isGround && combosu == 1 && hit)
        {


            StartCoroutine("attackair2");
            mukiair2(-1);
     

        }

        //空中攻撃１　Ｃ
        if (Input.GetKeyDown(KeyCode.C) && koutyokuair <= 0 && !isGround && combosu == 0 && !wazaair)

        {

            StartCoroutine("attackair1");
            mukiair1(1);
     
        }

        if (Input.GetKeyDown(KeyCode.C) && cansel >= 0 && !isGround && combosu == 1 && hit)
        {


            StartCoroutine("attackair2");
            mukiair2(1);
    

        }
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\




        //Ａボタンでジャンプ左
        if (Input.GetKeyDown(KeyCode.A) && isGround　&& koutyoku <= 0)
        {
            jump(-1);
        }


        //Ｄボタンでジャンプ右
        if (Input.GetKeyDown(KeyCode.D) && isGround && koutyoku <= 0)
        {
            jump(1);
        }


        //ターン
        //左を向く
        if (Input.GetKeyDown(KeyCode.LeftArrow) && koutyoku <= 0 && koutyokuair <= 0)
        {

            turn(-1);

        }
        //右を向く
        if (Input.GetKeyDown(KeyCode.RightArrow) && koutyoku <= 0 && koutyokuair <= 0)
        {

            turn(1);

        }

        //移動速度
        if (this.transform.localScale.x > 0 && koutyoku >= 0 && !isGround)
        {
            this.transform.position += new Vector3(speed, 0, 0);
        }
        else if (this.transform.localScale.x > 0 && koutyoku <= 0)
        {
            this.transform.position += new Vector3(speed, 0, 0);
        }
        if (this.transform.localScale.x < 0 && koutyoku >= 0 && !isGround)
        {
            this.transform.position += new Vector3(-speed, 0, 0);
        }
        else if(this.transform.localScale.x < 0 && koutyoku <= 0)
        {
            this.transform.position += new Vector3(-speed, 0, 0);
        }

        //死亡
        if(HP <= 0)
        {
            Debug.Log("死亡");
            dead = true;
            myAnimator.SetBool("deadbool", true);

        }

    }
}
