using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zakocontoroller : MonoBehaviour {

    //アニメーションするためのコンポーネントを入れる
    private Animator myAnimator;

    float speed = 0.01f;
    public int HP = 1;
    public GameObject hitboxenemy;

    //攻撃サイクル
    private float cycle = 0;
    
    //硬直
    public float koutyoku;
    public float cansel;
    public int combosu;
   
    //攻撃地上１
    public IEnumerator attack1()
    {

        yield return new WaitForSeconds(0.5f);
        //当たり判定を作成
        GameObject go = Instantiate(hitboxenemy) as GameObject;
        go.transform.position = new Vector2(this.transform.position.x + 1 * this.transform.localScale.x, this.transform.position.y);
        Destroy(go, 0.3f);
        //ダメージ
        go.GetComponent<hitboxenemycontroller>().damege = 1;

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


    // Use this for initialization
    void Start () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "hitboxplayer")
        {

            HP -= other.GetComponent<hitboxcontroller>().damege;
   
        }
    }



    // Update is called once per frame
    void Update () {

        this.transform.position += new Vector3(speed * this.transform.localScale.x, 0, 0);

        cycle += Time.deltaTime;
        if(cycle > 3)
        {
            cycle = 0;
            int a = Random.Range(1, 2);
                if(a == 1)
            {
                StartCoroutine("attack1");
            }
        }


        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}
