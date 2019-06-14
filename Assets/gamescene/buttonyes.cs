using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonyes : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
    }
	
	public void Onclick()
    {
        FadeManager.Instance.LoadScene("title", 1.0f);
    }
    // Update is called once per frame
	void Update () {
		
	}
}
