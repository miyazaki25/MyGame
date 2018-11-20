using UnityEngine;
using System.Collections;
using UnityEngine.UI; // ←※これを忘れずに入れる

public class HpBarCtrl : MonoBehaviour
{
    Slider _slider;
    private GameObject player;
    void Start()
    {
        // スライダーを取得する
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
        player = GameObject.FindWithTag("player");
    }

    public int _hp = 0;

    void Update()
    {

        _hp = player.GetComponent<playercontroller2>().HP;
        // HPゲージに値を設定
        _slider.value = _hp;
    }
}