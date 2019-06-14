using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemygeneratorcontroller : MonoBehaviour {

    int syutugen = 0;
    int gamen = 0;
    float cycle = 0;

    public GameObject zako;
    public GameObject zakoaka;
    public GameObject zakoao;
    public GameObject tako;
    public GameObject doragon;


    GameObject[] tagObjects;
    public bool[] layerNo = new bool[8];

    //画面内敵チェック関数
    void Check(string enemy)
    {
        tagObjects = GameObject.FindGameObjectsWithTag(enemy);
        gamen = tagObjects.Length;
        //tagObjects.Lengthはオブジェクトの数

    }
    //出現関数
    void kaimaku(int a)
    {
        GameObject go = Instantiate(zako) as GameObject;
        go.transform.position = new Vector2(a, -2);
        go.transform.localScale = new Vector2(-1, 1);
        syutugen += 1;
    }

    // Use this for initialization
    void Start () {
        syutugen = 0;
        gamen = 0;

        //開幕2体出現
        kaimaku(4);
        kaimaku(-4);
       
       
    }
	
	// Update is called once per frame
	void Update ()
    {
        //敵生成サイクル
        cycle += Time.deltaTime;
   
        if (cycle > 3 )
        {
            cycle = 0;

            Check("enemy");




            int n = Random.Range(1, 4);
            if (n == 1 && gamen < 5)
            {
                if (syutugen == 9 || syutugen ==19 || syutugen ==29 || syutugen ==39 ||syutugen==59 ||  syutugen >= 95 && syutugen <= 98 )
                {
                    GameObject go = Instantiate(zakoaka) as GameObject;
                    go.transform.position = new Vector2(11,-2);
                    go.transform.localScale = new Vector2(-1, 1);
                    syutugen += 1;
                }

                else if(syutugen == 49 || syutugen ==69 || syutugen == 79 || syutugen == 89)
                {
                    GameObject go = Instantiate(zakoao) as GameObject;
                    go.transform.position = new Vector2(11, -2);
                    go.transform.localScale = new Vector2(-1, 1);
                    syutugen += 1;
                }
                else if (syutugen == 14 || syutugen == 34 || syutugen == 50 || syutugen == 75 || syutugen == 80 || syutugen == 90 || syutugen == 96)
                {
                    GameObject go = Instantiate(tako) as GameObject;
                    go.transform.position = new Vector2(11, -2);
                    go.transform.localScale = new Vector2(-1, 1);
                    syutugen += 1;
                }

                else if (syutugen < 99)
                {
                    GameObject go = Instantiate(zako) as GameObject;
                    go.transform.position = new Vector2(11, -2);
                    go.transform.localScale = new Vector2(-1, 1);
                    syutugen += 1;

                }
                else if (syutugen == 99 && gamen ==0)
                {
                    GameObject go = Instantiate(doragon) as GameObject;
                    go.transform.position = new Vector2(11, -2);
                    go.transform.localScale = new Vector2(-1, 1);
                    syutugen += 1;

                }

            }

            //反転
            if (n == 2 && gamen < 5 )
            {
                if (syutugen == 9 || syutugen == 19 || syutugen == 29 || syutugen == 39 || syutugen == 59 || syutugen >= 95 && syutugen <= 98)
                {
                    GameObject go = Instantiate(zakoaka) as GameObject;
                    go.transform.position = new Vector2(-11, -2);
                    go.transform.localScale = new Vector2(1, 1);
                    syutugen += 1;
                }
                else if (syutugen == 49 || syutugen == 69 || syutugen == 79 || syutugen == 89)
                {
                    GameObject go = Instantiate(zakoao) as GameObject;
                    go.transform.position = new Vector2(-11, -2);
                    go.transform.localScale = new Vector2(-1, 1);
                    syutugen += 1;
                }
              else if (syutugen == 14 || syutugen == 34 || syutugen == 50 || syutugen == 75 || syutugen == 80 || syutugen == 90 || syutugen == 96)
                {
                    GameObject go = Instantiate(tako) as GameObject;
                    go.transform.position = new Vector2(-11, -2);
                    go.transform.localScale = new Vector2(-1, 1);
                    syutugen += 1;
                }
                else if (syutugen < 99)
                {
                    GameObject go = Instantiate(zako) as GameObject;
                    go.transform.position = new Vector2(-11, -2);
                    go.transform.localScale = new Vector2(1, 1);
                    syutugen += 1;
                }
                else if (syutugen == 99 && gamen == 0)
                {
                    GameObject go = Instantiate(doragon) as GameObject;
                    go.transform.position = new Vector2(-11, -2);
                    go.transform.localScale = new Vector2(1, 1);
                    syutugen += 1;
                }


            }
          
        }
    }
}
