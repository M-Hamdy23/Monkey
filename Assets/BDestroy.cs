using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDestroy : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.tag == "tree")
        {
            Destroy(this.gameObject);
        }
    }
}
