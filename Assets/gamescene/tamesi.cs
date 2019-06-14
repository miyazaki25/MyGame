using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tamesi : MonoBehaviour {

    // Use this for initialization
    int mylayer;
    public GameObject enemycon;
   

    //レイヤー使用戻し関数
    public void layermodosi()
    {
        enemycon.GetComponent<enemygeneratorcontroller>().layerNo[mylayer] = false;
    }


    void Start () {

        enemycon = GameObject.FindWithTag("enemycon");
        string layerName;

        for(int i = 0; i < 8; i++)
        {
            if (enemycon.GetComponent<enemygeneratorcontroller>().layerNo[i] == false)
            {
                layerName = "enemy" + i;
                Debug.Log(layerName);
                gameObject.SetLayer(layerName);
                enemycon.GetComponent<enemygeneratorcontroller>().layerNo[i] = true;
                mylayer = i;
                break;
            }
        }






    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
