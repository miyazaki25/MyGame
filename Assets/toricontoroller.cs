using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toricontoroller : MonoBehaviour
{

    float speed = 0.01f;
    public int HP = 1;

    
 
    
    
    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "hitboxplayer")
        {
            HP -= other.GetComponent<hitboxcontroller>().damege;
            Debug.Log("HP ="+ HP.ToString());
        }
    }



    // Update is called once per frame
    void Update()
    {

        this.transform.position += new Vector3(speed * this.transform.localScale.x, 0, 0);

        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}
