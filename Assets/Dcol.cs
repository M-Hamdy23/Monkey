using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dcol : MonoBehaviour {

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("jjjjjjjjjjj");
        if (collision.gameObject.tag == "tree")
        {
            Destroy(this.gameObject);
        }
    }
}
