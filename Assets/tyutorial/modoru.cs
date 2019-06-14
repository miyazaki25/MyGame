using UnityEngine;
using System.Collections;

public class modoru : MonoBehaviour
{
    public GameObject textcont;
    /// ボタンをクリックした時の処理
    public void OnClick()
    {
        textcont.GetComponent<texttyutorial>().SetDownLine();
  
    }
}
