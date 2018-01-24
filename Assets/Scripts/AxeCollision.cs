using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeCollision : MonoBehaviour {
    float damage= 10;

    public Tree target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject==target.gameObject)
    //    {
    //        collision.gameObject.GetComponent<Tree>().hp -= damage;
            
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (target)
        {
            if (collision.gameObject == target.gameObject)
            {
                collision.gameObject.GetComponent<Tree>().hp -= damage;

            }
        }
    }
}
