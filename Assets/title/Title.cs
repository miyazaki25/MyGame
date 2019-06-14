using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーンマネジメントを有効にする

public class Title : MonoBehaviour
{
    private static soundsingleton mInstance;
    soundsingleton soundsin;
    // Use this for initialization
    void Start()
    {
        //SE関係
        soundsin = soundsingleton.Instance;
        Invoke("BGMstart", 0.5f);
    }

    void BGMstart()
    {
        soundsin.sound0(9);
    }
    
    // Update is called once per frame
    void Update()
    {
     

    }
}