using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//シーンマネジメントを有効にする

public class textcontroller : MonoBehaviour {

    //BGM
    private static soundsingleton mInstance;
    soundsingleton soundsin;
    int BGMNo;

    private GameObject score;
    private GameObject gameover;
    int gekiha = 0;
    private bool gameoverhantei = false;
    //スコア上書き関数
    public void scorekousin()
    {
        gekiha += 1;
        //スコアを表示
        this.score.GetComponent<Text>().text = gekiha + "人抜き";

    }
    //ゲームオーバー関数
    public void gameoverkansu()
    {
        this.gameover.GetComponent<Text>().text =  "死";

        gameoverhantei = true;
        Invoke("title", 2f);
    }
    //タイトルへもどる
    private void title()
    {
        FadeManager.Instance.LoadScene("title", 2.0f);

    }
    //エンディング呼び出し
    private void ending()
    {
        FadeManager.Instance.LoadScene("ending", 2.0f);
        
    }

    // Use this for initialization
    void Start () {
        //SE関係
        soundsin = soundsingleton.Instance;
        //シーン中のscoreオブジェクトを取得
        this.score = GameObject.Find("score");
        this.gameover = GameObject.Find("gameover");
        //スコアを表示
        this.score.GetComponent<Text>().text = gekiha + "人抜き";
        gameoverhantei = false;
    }
	
	
    
    // Update is called once per frame
	void Update () {
      
      if(gekiha == 100)
        {
            Invoke("ending", 3f);
        }
      //BGMチェンジ
        if (gekiha >=  50 && gekiha < 99 && ( BGMNo > 1 || BGMNo < 1))
        {
            BGMNo = 1;
            soundsin.BGMchange(BGMNo);
        }
        if (gekiha >= 99 && (BGMNo > 2 || BGMNo < 2))
        {
            BGMNo = 2;
            soundsin.BGMchange(BGMNo);
        }
    }
}
