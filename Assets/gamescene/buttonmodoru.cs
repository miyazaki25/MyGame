using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonmodoru : MonoBehaviour {

    public GameObject buttonyes;
    public GameObject buttonno;
    public GameObject text;

    public void Onclick()
    {
        buttonyes.SetActive(true);
        buttonno.SetActive(true);
        text.SetActive(true);
 
    }
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
