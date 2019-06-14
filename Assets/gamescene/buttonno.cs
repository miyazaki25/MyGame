using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonno : MonoBehaviour {

    public GameObject buttonyes;
    public GameObject text;

    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);
    }

    public void Onclick()
    {
        gameObject.SetActive(false);
        buttonyes.SetActive(false);
        text.SetActive(false);
     
    }
    // Update is called once per frame
    void Update () {
		
	}
}
