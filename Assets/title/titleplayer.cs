using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleplayer : MonoBehaviour {

    //アニメーションするためのコンポーネントを入れる
    private Animator myAnimator;
    //攻撃サイクル
    private float cycle = 0;

    // Use this for initialization
    void Start () {
        this.myAnimator = GetComponent<Animator>();
        myAnimator.SetBool("groundbool", true);
    }
	
	// Update is called once per frame
	void Update () {

        cycle += Time.deltaTime;
        if(cycle > 4)
        {
            int d = Random.Range(1, 6);
            if (d > 0)
            {
                myAnimator.SetTrigger("atacktrriger");
            }
            cycle = 0;
        }
       
    }
}
