using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;//シーンマネジメントを有効にする

public class dojobutton : MonoBehaviour
{
    private static soundsingleton mInstance;
    soundsingleton soundsin;

    void Start()
    {
        //SE関係
        soundsin = soundsingleton.Instance;

    }
    /// ボタンをクリックした時の処理
    public void OnClick()
    {
        soundsin.sound0(4);
        FadeManager.Instance.LoadScene("tyutorial", 1.0f);
        Debug.Log("dojo click!");
    }
}
