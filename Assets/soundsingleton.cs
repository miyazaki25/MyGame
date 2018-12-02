using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class soundsingleton : MonoBehaviour
{

    private static soundsingleton mInstance;

    public GameObject sound;

    private soundsingleton()
    { // Private Constructor

        Debug.Log("Create SampleSingleton GameObject instance.");
    }

    public static soundsingleton Instance
    {

        get
        {

            if (mInstance == null)
            {

                GameObject go = new GameObject("soundsingleton");
                mInstance = go.AddComponent<soundsingleton>();
            }

            return mInstance;
        }
    }

    //SE関係
    public AudioSource[] audioSource;

    public AudioClip[] audioclip = new AudioClip[10];

    void Start()
    {
        sound = GameObject.Find("sound");
        audioSource = sound.gameObject.GetComponents<AudioSource>();
   
        for (int i = 0; i < audioclip.Length; i++)
        {
            audioclip[i] = sound.gameObject.GetComponent<sound>().audioclip[i];

        }
    }


    public void sound0(int a)
    {
        Debug.Log("サウンドサイセイ");
        audioSource[0].PlayOneShot(audioclip[a]);
    }

    void Update()
    {

    }
}