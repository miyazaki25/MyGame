using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;//シーンマネジメントを有効にする

public class endbutton : MonoBehaviour
{

    private void Start()
    {
      
    }
    /// ボタンをクリックした時の処理
    public void OnClick()
    {
        FadeManager.Instance.LoadScene("title", 1.0f);
      
    }
}
