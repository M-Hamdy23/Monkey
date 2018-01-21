using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    
    public GameObject player;
    public float speed=1;
    public Rigidbody2D rigid;
    
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        rigid = gameObject.GetComponent<Rigidbody2D>();
        if (!player)
        {
            Debug.Log("not found player tag");
        }
	}
	
	// Update is called once per frame
	void Update () {
        //transform.LookAt(player.transform);

        float dir = player.transform.position.x - transform.position.x;
        rigid.velocity = new Vector2(dir/Mathf.Abs(dir)*speed,0);
        
            
        
    }
}
