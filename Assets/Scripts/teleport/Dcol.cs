using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dcol : MonoBehaviour {

    public Moveplayer thePlayer;

    private Vector3 newPlayerPos;
    //float lifetime = 2.0f;
    void Start()
    {
        thePlayer = FindObjectOfType<Moveplayer>();
       // lastPlayerPos = thePlayer.transform.position;

    }
    void Update()
    {
        Destroy(gameObject, 5); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("jjjjjjjjjjj");
        if (collision.gameObject.tag == "tree")
        {
            thePlayer.transform.position = transform.position ;
            Destroy(gameObject);
        }
    }
    
}
