using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class uitextcont : MonoBehaviour
{
    //SE関係
    private static soundsingleton mInstance;
    soundsingleton soundsin;

    public string[] scenarios;
    [SerializeField] Text uiText;

    [SerializeField]
    [Range(0.001f, 0.3f)]
    float intervalForCharacterDisplay = 0.05f;  // 1文字の表示にかかる時間

    private int currentLine = 0;
    private string currentText = string.Empty;  // 現在の文字列
    private float timeUntilDisplay = 0;     // 表示にかかる時間
    private float timeElapsed = 1;          // 文字列の表示を開始した時間
    private int lastUpdateCharacter = -1;       // 表示中の文字数

    int a = 0;
    public GameObject endbutton;
    public GameObject dragon;
    public GameObject panel;
    public GameObject nextbutton;
    public GameObject maincamera;
    public GameObject ninja;
    public GameObject hime;
    public GameObject endingtext;
    private int movieno;

    IEnumerator movie() //ムービー開始
    {
            yield return new WaitForSeconds(3);
        ninja.GetComponent<Animator>().SetTrigger("runtrriger");
        movieno = 1;
        yield return new WaitForSeconds(2.5f);
        ninja.GetComponent<Animator>().SetTrigger("idletrriger");
        movieno = 2;
        yield return new WaitForSeconds(2);
        ninja.GetComponent<Animator>().SetTrigger("runtrriger");
        movieno = 3;
        yield return new WaitForSeconds(2);
        ninja.GetComponent<Animator>().SetTrigger("idletrriger");
        movieno = 2;
        yield return new WaitForSeconds(2);
        soundsin.sound0(0);
        ninja.GetComponent<Animator>().SetTrigger("jumptrriger");
        movieno = 4;
        yield return new WaitForSeconds(4);
        endingtext.gameObject.SetActive(true);

    }
    void Start()
    {
        //SE関係
        soundsin = soundsingleton.Instance;
        endingtext.gameObject.SetActive(false);
        SetNextLine();
        movieno = 0;
      

    }

    void Update()
    {


        // クリックから経過した時間が想定表示時間の何%か確認し、表示文字数を出す
        int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUntilDisplay) * currentText.Length);

        // 表示文字数が前回の表示文字数と異なるならテキストを更新する
        if (displayCharacterCount != lastUpdateCharacter)
        {
            uiText.text = currentText.Substring(0, displayCharacterCount);
            lastUpdateCharacter = displayCharacterCount;
        }
        if (currentLine + 1 >= scenarios.Length && a == 0)
        {
            Debug.Log("終わり");
            dragon.GetComponent<Animator>().SetTrigger("dead");
            soundsin.sound0(9);
            Destroy(dragon.gameObject, 1.6f);

            StartCoroutine(movie());
            Destroy(uiText, 3);
            Destroy(nextbutton, 3);
            Destroy(panel, 3);

            // Buttonを表示する
            MyCanvas.SetActive("ButtonEnd", true);
            a = 1;


        }
        //テキストが最後までいったら
        if (currentLine == scenarios.Length)
        {
            Debug.Log("end");


        }
        //ムービー制御
        if(movieno == 1)
        {
            ninja.gameObject.transform.Translate(new Vector3(-0.04f, 0.0f, 0.0f));
            maincamera.gameObject.transform.Translate(new Vector3(-0.04f, 0.0f, 0.0f));
        }
        else if (movieno ==3)
        {
            ninja.gameObject.transform.Translate(new Vector3(-0.02f, 0.0f, 0.0f));
            maincamera.gameObject.transform.Translate(new Vector3(-0.02f, 0.0f, 0.0f));
        }
        else if (movieno == 4)
        {
            ninja.gameObject.transform.Translate(new Vector3(-0.02f, 0.08f, 0.0f));
            hime.gameObject.transform.Translate(new Vector3(-0.02f, 0.08f, 0.0f));
        }


        
        
    }


    public void SetNextLine()
    {
        if (currentLine + 1 < scenarios.Length)
        {
            currentLine++;
            currentText = scenarios[currentLine];


            // 想定表示時間と現在の時刻をキャッシュ
            timeUntilDisplay = currentText.Length * intervalForCharacterDisplay;
            timeElapsed = Time.time;

            // 文字カウントを初期化
            lastUpdateCharacter = -1;
        }

    }
    public void SetDownLine()
    {
        if (currentLine < scenarios.Length && currentLine > 1)
        {
            currentLine--;
            currentText = scenarios[currentLine];


            // 想定表示時間と現在の時刻をキャッシュ
            timeUntilDisplay = currentText.Length * intervalForCharacterDisplay;
            timeElapsed = Time.time;

            // 文字カウントを初期化
            lastUpdateCharacter = -1;
        }


       
    }
  
}
