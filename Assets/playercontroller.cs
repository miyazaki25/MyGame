using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour {
    //アニメーションするためのコンポーネントを入れる
    private Animator myAnimator;
    //移動速度
    private float speed = 0.01f;
    //ジャンプパワー
    private float jump = 10f;
    //プレイヤーを移動させるコンポーネントを入れる
    Rigidbody2D rigid2D;
    //地面
    private float ground = -3.1f;

    // Use this for initialization
    void Start () {
        // Rigidbody2Dのコンポーネントを取得する（追加）
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.myAnimator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        //地面判定
        bool isGround = (transform.position.y > this.ground) ? false : true;
        //左を向く
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            //localScaleを変数に格納
            Vector2 temp = gameObject.transform.localScale;
            //localScale.xを-2にする
            temp.x = -2;
            //結果を戻す
            gameObject.transform.localScale = temp;

        }
        //右を向く
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            //localScaleを変数に格納
            Vector2 temp = gameObject.transform.localScale;
            //localScale.xを2にする
            temp.x = 2;
            //結果を戻す
            gameObject.transform.localScale = temp;

        }


        //Ｚボタンで攻撃左
        if (Input.GetKeyDown(KeyCode.Z) && isGround)
        {
            
            //localScaleを変数に格納
            Vector2 temp = gameObject.transform.localScale;
            //localScale.xを-2にする
            temp.x = -2;
            //結果を戻す
            gameObject.transform.localScale = temp;
            myAnimator.SetTrigger("atacktrriger");

         }
        //空中Ｚボタンで攻撃左
        if (Input.GetKeyDown(KeyCode.Z) && !isGround)
        {

            //localScaleを変数に格納
            Vector2 temp = gameObject.transform.localScale;
            //localScale.xを-2にする
            temp.x = -2;
            //結果を戻す
            gameObject.transform.localScale = temp;
            myAnimator.SetTrigger("jumpattacktrriger");

        }

        //Ｃボタンで攻撃右
        if (Input.GetKeyDown(KeyCode.C) && isGround)
        {
            //localScaleを変数に格納
            Vector2 temp = gameObject.transform.localScale;
            //localScale.xを2にする
            temp.x = 2;
            //結果を戻す
            gameObject.transform.localScale = temp;

            myAnimator.SetTrigger("atacktrriger");
        }
        //Ｃボタンで攻撃右
        if (Input.GetKeyDown(KeyCode.C) && !isGround)
        {
            //localScaleを変数に格納
            Vector2 temp = gameObject.transform.localScale;
            //localScale.xを2にする
            temp.x = 2;
            //結果を戻す
            gameObject.transform.localScale = temp;

            myAnimator.SetTrigger("jumpattacktrriger");
        }

        //Ａボタンでジャンプ左
        if (Input.GetKeyDown(KeyCode.A) && isGround)
        {
            //localScaleを変数に格納
            Vector2 temp = gameObject.transform.localScale;
            //localScale.xを-2にする
            temp.x = -2;
            //結果を戻す
            gameObject.transform.localScale = temp;
            myAnimator.SetTrigger("jumptrriger");

            //上方向に力をくわえる
            this.rigid2D.velocity = new Vector2(0, this.jump);
        }

        //Ｄボタンでジャンプ右
        if (Input.GetKeyDown(KeyCode.D) && isGround)
        {
           

            //localScaleを変数に格納
            Vector2 temp = gameObject.transform.localScale;
            //localScale.xを2にする
            temp.x = 2;
            //結果を戻す
            gameObject.transform.localScale = temp;
            myAnimator.SetTrigger("jumptrriger");
            //上方向に力をくわえる
            this.rigid2D.velocity = new Vector2(0, this.jump);
        }

        if(this.transform.localScale.x > 0)
        {
            this.transform.position += new Vector3(speed, 0, 0);
        }
        if (this.transform.localScale.x < 0)
        {
            this.transform.position += new Vector3(-speed, 0, 0);
        }
    }

}
