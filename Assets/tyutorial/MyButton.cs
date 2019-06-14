using UnityEngine;
using System.Collections;

public class MyButton : MonoBehaviour
{
    public GameObject textcont;
    /// ボタンをクリックした時の処理
    public void OnClick()
    {
        textcont.GetComponent<texttyutorial>().SetNextLine();
        Debug.Log("Button2 click!");


    }
}
