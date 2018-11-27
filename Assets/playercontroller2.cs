using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller2 : MonoBehaviour {
   
    
    //HP
    public int HP;
    //SE関係
    private AudioSource[] audioSource;
 
    public AudioClip[] sound = new AudioClip[5];
    private int chagese;
    
    
    //アニメーションするためのコンポーネントを入れる
    private Animator myAnimator;
    //テキストコントローラー
    private GameObject textcontroller;
    //移動速度
    private float speed = 0.02f;
    //ジャンプパワー
    private float jumppow = 10f;
    //プレイヤーを移動させるコンポーネントを入れる
    Rigidbody2D rigid2D;
    //硬直
    public float koutyoku;

    //空中硬直
    public float koutyokuair;
    //被弾硬直
    public float hidankoutyoku;

    //空中ワザ
    bool wazaair;

    //地面判定
    public bool isGround;

    //死亡判定
    private bool dead = false;

    //地面
    private float ground = -3.65f;

    //攻撃関係
    public GameObject hitbox;
    public GameObject tama;
    public int hitsu;
    public float cansel = 0;
    int combosu;
    public float hitkoutyoku;

    public bool hit;

    //死体
    public GameObject deadbody;

    //タメ時間
    private float tamezikan = 0;


    //攻撃関数\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    //攻撃ヒット時に呼び出す関数
    public void hithantei()
    {
        hit = true;
    }


 
    //攻撃地上１
    public IEnumerator attack1(int muki)
    {
        //向きを変更
        Vector2 temp = gameObject.transform.localScale;
        temp.x = muki;
        gameObject.transform.localScale = temp;

        //硬直に代入
        koutyoku = 1f;
        //ヒット硬直
        hitkoutyoku = 0.8f;

        //キャンセル可能時間
        cansel = 0.7f;
        //コンボ数をふやす
        combosu = 1;
        myAnimator.SetTrigger("atacktrriger");

        //横方向に力をくわえる
        this.rigid2D.velocity = new Vector2(2 * muki, 0);
        //音を鳴らす
        audioSource[0].PlayOneShot(sound[0]);
        yield return new WaitForSeconds(0.2f);
     

        //当たり判定を作成
        GameObject go = Instantiate(hitbox) as GameObject;

       go.transform.position = new Vector2(this.transform.position.x + 1 * this.transform.localScale.x, this.transform.position.y);
        go.transform.localScale = new Vector3(0.7f * this.gameObject.transform.localScale.x, 0.5f, 1);
        Destroy(go, 0.3f);
        //ダメージ、吹っ飛び、ＳＥ
        go.GetComponent<hitboxcontroller>().damege = 1;
        go.GetComponent<hitboxcontroller>().futtobix = 0;
        go.GetComponent<hitboxcontroller>().futtobiy = 0;
        go.GetComponent<hitboxcontroller>().sound = sound[2];

    }


    //攻撃地上２
    public IEnumerator attack2(int muki)
    {
        //向きを変更
       　Vector2 temp = gameObject.transform.localScale;
        temp.x = muki;
        gameObject.transform.localScale = temp;
        //硬直に代入
        koutyoku = 0.8f;

        //ヒット硬直
        hitkoutyoku = 0.8f;

        //キャンセル可能時間
        cansel = 0.7f;

        //コンボ数をふやす
        combosu = 2;

        myAnimator.SetTrigger("attacktrriger2");

        //横方向に力をくわえる
        this.rigid2D.velocity = new Vector2(0 * muki, 0);

        audioSource[0].PlayOneShot(sound[2]);

        //当たり判定を作成
        yield return new WaitForSeconds(0.2f);
        GameObject go = Instantiate(hitbox) as GameObject;
        go.transform.position = new Vector2(this.transform.position.x + 1 * this.transform.localScale.x, this.transform.position.y);
        go.transform.localScale = new Vector3(0.7f * this.gameObject.transform.localScale.x, 0.5f, 1);
        Destroy(go, 0.6f);
        go.GetComponent<hitboxcontroller>().damege = 1;

    }


    //攻撃地上3
    public IEnumerator attack3(int muki)
    {
        //向きを変更
        Vector2 temp = gameObject.transform.localScale;
        temp.x = muki;
        gameObject.transform.localScale = temp;

        //硬直に代入
        koutyoku = 1f;
        //ヒット硬直
        hitkoutyoku = 0.8f;

        //キャンセル可能時間
        cansel = 0.7f;
        //コンボ数をふやす
        combosu = 3;
        myAnimator.SetTrigger("atacktrriger");

        //横方向に力をくわえる
        this.rigid2D.velocity = new Vector2(0 * muki, 0);

        //音を鳴らす
        audioSource[0].PlayOneShot(sound[3]);

        yield return new WaitForSeconds(0.2f);

    

        //当たり判定を作成
        GameObject go = Instantiate(hitbox) as GameObject;
        go.transform.position = new Vector2(this.transform.position.x + 1 * this.transform.localScale.x, this.transform.position.y);
        go.transform.localScale = new Vector3(0.7f * this.gameObject.transform.localScale.x, 0.5f, 1);
        Destroy(go, 0.3f);
        //ダメージ
        go.GetComponent<hitboxcontroller>().damege = 2;
        go.GetComponent<hitboxcontroller>().futtobix = 2;
        go.GetComponent<hitboxcontroller>().futtobiy = 2;

    }

    //空中攻撃1
    public IEnumerator attackair1(int muki)
    {
        //向きを変更
        Vector2 temp = gameObject.transform.localScale;
        temp.x = muki;
        gameObject.transform.localScale = temp;
        //硬直に代入
        koutyokuair = 1.2f;

        //キャンセル可能時間
        cansel = 0.7f;

        //ヒット硬直
        hitkoutyoku = 0.8f;

        //コンボ数をふやす
        combosu = 1;

        myAnimator.SetTrigger("jumpattacktrriger");

        //空中攻撃判定
        wazaair = true;


        //当たり判定を作成
        yield return new WaitForSeconds(0.2f);
        GameObject go = Instantiate(hitbox) as GameObject;
        go.transform.position = new Vector2(this.transform.position.x + 1 * this.transform.localScale.x , this.transform.position.y);
        Destroy(go, 0.8f);
        go.GetComponent<hitboxcontroller>().damege = 1;

    }
  
    //空中攻撃2
    public IEnumerator attackair2(int muki)
    {
        //向きを変更
        Vector2 temp = gameObject.transform.localScale;
        temp.x = muki;
        gameObject.transform.localScale = temp;
        //硬直に代入
        koutyokuair = 1.2f;

        //ヒット硬直
        hitkoutyoku = 0.8f;

        //キャンセル可能時間
        cansel = 0.7f;

        //コンボ数をふやす
        combosu = 2;

        myAnimator.SetTrigger("jumpattacktrriger");

        //空中攻撃判定
        wazaair = true;

        //当たり判定を作成
        yield return new WaitForSeconds(0.25f);
        GameObject go = Instantiate(hitbox) as GameObject;
        go.transform.position = new Vector2(this.transform.position.x + 1 * this.transform.localScale.x, this.transform.position.y);
        Destroy(go, 0.6f);
        go.GetComponent<hitboxcontroller>().damege = 1;
    }
    //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    //ファイアボール
    public IEnumerator fireboll(int muki)
    {
        //向きを変更
        Vector2 temp = gameObject.transform.localScale;
        temp.x = muki;
        gameObject.transform.localScale = temp;

        //硬直に代入
        koutyoku = 1.8f;
        //ヒット硬直
        hitkoutyoku = 0.8f;

        //キャンセル可能時間
        cansel = 0f;
        //コンボ数をふやす
        combosu = 1;
        myAnimator.SetTrigger("firebolltirrger");

        //横方向に力をくわえる
        this.rigid2D.velocity = new Vector2(0 * muki, 0);

        yield return new WaitForSeconds(0.2f);
        //当たり判定を作成
        GameObject go = Instantiate(tama) as GameObject;
        go.transform.position = new Vector2(this.transform.position.x + 1 * this.transform.localScale.x, this.transform.position.y);
        Destroy(go, 3);
        //ダメージ
        go.GetComponent<tamacontoroller>().damege = 2;

    }

    //サマーソルト
    public IEnumerator samaso(int muki)
    {
        //向きを変更
        Vector2 temp = gameObject.transform.localScale;
        temp.x = muki;
        gameObject.transform.localScale = temp;

        //硬直に代入
        koutyoku = 2.0f;
        //ヒット硬直
        hitkoutyoku = 0.8f;

        //キャンセル可能時間
        cansel = 0f;
        //コンボ数をふやす
        combosu = 1;
        myAnimator.SetTrigger("samasotrriger");

        //横方向に力をくわえる
        this.rigid2D.velocity = new Vector2(0 * muki, 10);

        yield return new WaitForSeconds(0.2f);
        //当たり判定を作成
        GameObject go = Instantiate(hitbox) as GameObject;
        go.transform.position = new Vector2(this.transform.position.x + 1 * this.transform.localScale.x, this.transform.position.y+1);
        go.transform.localScale =new Vector3 (0.7f, 2, 1);
        Destroy(go, 0.3f);
        //ダメージ
        go.GetComponent<hitboxcontroller>().damege = 1;

    }
    //てつざんこう
    public IEnumerator tetuzan(int muki)
    {
        //向きを変更
        Vector2 temp = gameObject.transform.localScale;
        temp.x = muki;
        gameObject.transform.localScale = temp;

        //硬直に代入
        koutyoku = 2.0f;
        //ヒット硬直
        hitkoutyoku = 0.8f;

        //キャンセル可能時間
        cansel = 0f;
        //コンボ数をふやす
        combosu = 1;
        myAnimator.SetTrigger("tetuzantrriger");

        //横方向に力をくわえる
        this.rigid2D.velocity = new Vector2(5 * muki, 0);

        yield return new WaitForSeconds(0.2f);
        //当たり判定を作成
        GameObject go = Instantiate(hitbox) as GameObject;
        go.transform.position = new Vector2(this.transform.position.x + 1 * this.transform.localScale.x, this.transform.position.y );
        go.transform.localScale = new Vector3(1, 1, 1);
        Destroy(go, 0.3f);
        //ダメージ
        go.GetComponent<hitboxcontroller>().damege = 5;
        yield return null;
        go.transform.position = new Vector2(this.transform.position.x + 1.2f * this.transform.localScale.x, this.transform.position.y);
        yield return null;
        go.transform.position = new Vector2(this.transform.position.x + 1.5f * this.transform.localScale.x, this.transform.position.y);
        yield return null;
        go.transform.position = new Vector2(this.transform.position.x + 1.5f * this.transform.localScale.x, this.transform.position.y);
    }

    //必殺技コルーチン
    IEnumerator hissatuzi()
    {
        if (Input.GetKeyDown(KeyCode.A) && koutyoku <= 0)
        {
            StartCoroutine("samaso", -1);
            tamezikan = 0;
            yield break;
        }
        else if (Input.GetKeyDown(KeyCode.D) && koutyoku <= 0)
        {
            StartCoroutine("samaso", 1);
            tamezikan = 0;
            yield break;
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow) && koutyoku <= 0)
        {
            StartCoroutine("tetuzan", -1);
            tamezikan = 0;
            yield break;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && koutyoku <= 0)
        {
            StartCoroutine("tetuzan", 1);
            tamezikan = 0;
            yield break;
        }
        else if (Input.GetKeyDown(KeyCode.C) && isGround && koutyoku <= 0)
        {
            StartCoroutine("fireboll", 1);
            tamezikan = 0;
            yield break;
        }
    }
    //必殺技コルーチン
    IEnumerator hissatuci()
    {
        if (Input.GetKeyDown(KeyCode.A) && koutyoku <= 0)
        {
            StartCoroutine("samaso", -1);
            tamezikan = 0;
            yield break;
        }
        else if (Input.GetKeyDown(KeyCode.D) && koutyoku <= 0)
        {
            StartCoroutine("samaso", 1);
            tamezikan = 0;
            yield break;
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow) && koutyoku <= 0)
        {
            StartCoroutine("tetuzan", -1);
            tamezikan = 0;
            yield break;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && koutyoku <= 0)
        {
            StartCoroutine("tetuzan", 1);
            tamezikan = 0;
            yield break;
        }
        else if (Input.GetKeyDown(KeyCode.Z) && isGround && koutyoku <= 0)
        {
            StartCoroutine("fireboll", -1);
            tamezikan = 0;
            yield break;
        }
    }


    //実践
    IEnumerator hissatuz(int muki)
    {
        StartCoroutine("hissatuzi");

        yield return null;
        StartCoroutine("hissatuzi");

        yield return null;
        StartCoroutine("hissatuzi");

        yield return null;
        StartCoroutine("hissatuzi");
        if (isGround && koutyoku <= 0)
        {
                StartCoroutine("fireboll", muki);
                tamezikan = 0;
            yield break;
           
        }
    }
    //必殺技コルーチン２
    IEnumerator hissatuc(int muki)
    {
        StartCoroutine("hissatuci");
        yield return null;
        StartCoroutine("hissatuci");
        yield return null;
        StartCoroutine("hissatuci");
        yield return null;
        StartCoroutine("hissatuci");
        if (isGround && koutyoku <= 0)
        {
            StartCoroutine("fireboll", muki);
            tamezikan = 0;
            yield break;
        }
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
    public void hidan(int a, float b ,float c, float d)
    {
       if(hidankoutyoku <= 0)
        {
            HP -= a;
            hidankoutyoku = b;

            Debug.Log(a.ToString() + "ダメージ" + "残りＨＰ" + HP.ToString() + "硬直" + hidankoutyoku);
            this.rigid2D.velocity = new Vector2(-this.gameObject.transform.localScale.x * c, d);
        }
      
    }



    // Use this for initialization
    void Start()
    {
        HP = 10;
        this.myAnimator = GetComponent<Animator>();
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.textcontroller = GameObject.Find("textcontroller");
      //conponetsのsが大事
        audioSource = gameObject.GetComponents<AudioSource>();

        //SE関係
   
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

        //被弾硬直を減らす && 硬直に代入 
        if (hidankoutyoku >= 0)
        {
            this.hidankoutyoku -= Time.deltaTime;
            this.myAnimator.SetFloat("hidanfloat", hidankoutyoku);
            koutyoku = hidankoutyoku;
            koutyokuair = hidankoutyoku;
        }

        //空中ワザ判定をリセット
        if (isGround && wazaair == true)
        {
            wazaair = false;
        }
        //空中硬直をリセット
        if(isGround && koutyokuair > 0)
        {
            koutyokuair = 0;
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

        //タメ時間を増やす
        if(Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.C) )
        {
            tamezikan += Time.deltaTime;
        }



        //攻撃実行\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        //タメ攻撃
        if (Input.GetKeyUp(KeyCode.Z) && tamezikan > 2)
        {
            StartCoroutine("hissatuz" , -1);
        }
        if (Input.GetKeyUp(KeyCode.C) && tamezikan > 2)
        {
            StartCoroutine("hissatuc", 1);
        }

        //地上攻撃1 Z
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (koutyoku <= 0 && isGround && tamezikan > 2)
            {
                StartCoroutine("fireboll",-1);
            }
            else if (koutyoku <= 0 && isGround && combosu == 0)
            {
              StartCoroutine("attack1",-1);
  
            }
            else if (hidankoutyoku <=0 && cansel >= 0 && isGround && combosu == 1 && hit)
            {
                StartCoroutine("attack2",-1); 
         
            }
            else if (hidankoutyoku <= 0 && cansel >= 0 && isGround && combosu == 2 && hit)
            {
                StartCoroutine("attack3", -1);

            }


        }


        //地上攻撃1 C
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (koutyoku <= 0 && isGround && tamezikan > 2)
            {
                StartCoroutine("fireboll", 1);
            }
            else if (koutyoku <= 0 && isGround && combosu == 0)
            {

                StartCoroutine("attack1",1);
               
            }
            else if (hidankoutyoku <= 0 && cansel >= 0 && isGround && combosu == 1 && hit)
            {
                StartCoroutine("attack2",1);
            }
            else if (hidankoutyoku <= 0 && cansel >= 0 && isGround && combosu == 2 && hit)
            {
                StartCoroutine("attack3", 1);
            }
        }
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        //空中攻撃1 Z
        if (Input.GetKeyDown(KeyCode.Z) && koutyokuair <= 0 && !isGround && combosu == 0  && !wazaair)

        {


            StartCoroutine("attackair1",-1);
        }
        if (Input.GetKeyDown(KeyCode.Z) && cansel >= 0 && !isGround && combosu == 1 && hit)
        {


            StartCoroutine("attackair2",-1);

        }

        //空中攻撃１　Ｃ
        if (Input.GetKeyDown(KeyCode.C) && koutyokuair <= 0 && !isGround && combosu == 0 && !wazaair)

        {

            StartCoroutine("attackair1",1);
     
        }

        if (Input.GetKeyDown(KeyCode.C) && cansel >= 0 && !isGround && combosu == 1 && hit)
        {


            StartCoroutine("attackair2",1);
    

        }
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\




        //Ａボタンでジャンプ左
        if (Input.GetKeyDown(KeyCode.A) && isGround　&& koutyoku <= 0)
        {
            jump(-1);
            //音を鳴らす
            audioSource[0].PlayOneShot(sound[1]);

        }


        //Ｄボタンでジャンプ右
        if (Input.GetKeyDown(KeyCode.D) && isGround && koutyoku <= 0)
        {
            jump(1);
            //音を鳴らす
            audioSource[0].PlayOneShot(sound[1]);
        }


        //ターン
        //左を向く
        if (Input.GetKeyDown(KeyCode.LeftArrow) && koutyoku <= 0 && koutyokuair <= 0)
        {
            turn(-1);
        }
            //右を向く
        if (Input.GetKeyDown(KeyCode.RightArrow) &&koutyoku <= 0 && koutyokuair <= 0)
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
        if(HP <= 0 && !dead)
        {
            Debug.Log("死亡");
            dead = true;
            GameObject go = Instantiate(deadbody) as GameObject;
            go.transform.position = new Vector2(this.transform.position.x , this.transform.position.y);
            Destroy(this.gameObject);
            this.textcontroller.GetComponent<textcontroller>().gameoverkansu();
        }
        //タメ時間をリセット
        if (!Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.C) && tamezikan >= 0)
        {
            tamezikan = 0;
        }

        //エフェクト関係
        if(tamezikan > 0.5f && tamezikan <= 2)
        {
            GetComponent<ParticleSystem>().Play();
            ParticleSystem.MainModule par = GetComponent<ParticleSystem>().main;
            par.startColor = Color.yellow;
            if (chagese == 0)
            {
                audioSource[2].Play();
                chagese = 1;
            }
         
        }
        else if(tamezikan > 2)
        {
            GetComponent<ParticleSystem>().Play();
            ParticleSystem.MainModule par = GetComponent<ParticleSystem>().main;
            par.startColor = Color.red;
            if(chagese == 1)
            {
                audioSource[0].PlayOneShot(sound[4]);
                chagese = 2;
            }
      
        }
        else if(tamezikan <= 0.5f)
        {
            GetComponent<ParticleSystem>().Stop();

            if (chagese == 2)
            {
                audioSource[2].Stop();
                chagese = 0;
            }
        }
    }
}
