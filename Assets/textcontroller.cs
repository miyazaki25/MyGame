using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textcontroller : MonoBehaviour {

    private GameObject score;
    private GameObject gameover;
    int gekiha = 0;

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
        this.gameover.GetComponent<Text>().text =  "ゲームオーバー";
    }


    // Use this for initialization
    void Start () {
        //シーン中のscoreオブジェクトを取得
        this.score = GameObject.Find("score");
        this.gameover = GameObject.Find("gameover");
        //スコアを表示
        this.score.GetComponent<Text>().text = gekiha + "人抜き";
    }
	
	
    
    // Update is called once per frame
	void Update () {
		
	}
}
