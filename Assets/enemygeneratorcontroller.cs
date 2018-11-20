using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemygeneratorcontroller : MonoBehaviour {

    int syutugen = 0;
    int gamen = 0;
    float cycle = 0;

    public GameObject zako;
    public GameObject tori;
    public GameObject zako2;


    GameObject[] tagObjects;

    //画面内敵チェック関数
    void Check(string enemy)
    {
        tagObjects = GameObject.FindGameObjectsWithTag(enemy);
        gamen = tagObjects.Length;
        //tagObjects.Lengthはオブジェクトの数

    }


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update ()
    {
        //敵生成サイクル
        cycle += Time.deltaTime;
   
        if (cycle > 2 )
        {
            cycle = 0;

            Check("enemy");




            int n = Random.Range(1, 4);
            if (n == 1 && gamen < 5)
            {
                if (syutugen == 2)
                {
                    GameObject go = Instantiate(tori) as GameObject;
                    go.transform.position = new Vector2(9,1f);
                    go.transform.localScale = new Vector2(-1, 1);
                    syutugen += 1;
                }

                else if(syutugen == 1)
                {
                    GameObject go = Instantiate(zako2) as GameObject;
                    go.transform.position = new Vector2(9, 1f);
                    go.transform.localScale = new Vector2(-1, 1);
                    syutugen += 1;
                }


                else if (syutugen < 100)
                {
                    GameObject go = Instantiate(zako) as GameObject;
                    go.transform.position = new Vector2(9, -3.15f);
                    go.transform.localScale = new Vector2(-1, 1);
                    syutugen += 1;

                }

            }

            //反転
            if (n == 2 && gamen < 5 )
            {
                    if (syutugen == 2)
                    {
                        GameObject go = Instantiate(tori) as GameObject;
                        go.transform.position = new Vector2(-9, 1f);
                        go.transform.localScale = new Vector2(1, 1);
                        syutugen += 1;
                    }
                   else if (syutugen == 1)
                   {
                    GameObject go = Instantiate(zako2) as GameObject;
                    go.transform.position = new Vector2(9, 1f);
                    go.transform.localScale = new Vector2(-1, 1);
                    syutugen += 1;
                    }
                   else if (syutugen < 100)
                    {
                        GameObject go = Instantiate(zako) as GameObject;
                        go.transform.position = new Vector2(-9, -3.15f);
                        go.transform.localScale = new Vector2(1, 1);
                    }      syutugen += 1;
                    

            }
          
        }
    }
}
