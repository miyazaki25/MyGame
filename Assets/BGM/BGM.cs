using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour {
    public int BGMNo;
    private static soundsingleton mInstance;
    soundsingleton soundsin;
    void BGMstart()
    {
        soundsin.BGMchange(BGMNo);
    }
	// Use this for initialization
	void Start () {
        //SE関係
        soundsin = soundsingleton.Instance;
        Invoke("BGMstart", 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
