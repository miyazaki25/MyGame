using UnityEngine;
using System.Collections;

public class tuzi : MonoBehaviour
{
    public GameObject textcont;
    /// ボタンをクリックした時の処理
    public void OnClick()
    {
        textcont.GetComponent<uitextcont>().SetNextLine();
        Debug.Log("Button2 click!");


    }
}
