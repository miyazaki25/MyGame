﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitboxenemycontroller : MonoBehaviour
{

    public int damege = 0;
    public float hitkoutyoku = 0;
    public float huttobix = 0;
    public float huttobiy = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {
            other.GetComponent<playercontroller2>().hidan(damege, hitkoutyoku,huttobix,huttobiy);

        }
    }
}
