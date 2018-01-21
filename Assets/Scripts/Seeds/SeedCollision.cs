using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedCollision : MonoBehaviour {
    public GameObject TreePrefab;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hi");
        if (collision.gameObject.CompareTag("dirt"))
        {
            
          GameObject bulletInstance = Instantiate(TreePrefab, collision.transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;

            Debug.Log(("ssgw"));
            var treepos = collision.gameObject.GetComponent<Transform>().position;
            Destroy(this);
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("dirt"))
    //    {
    //        Debug.Log(("ssgw"));
    //    }
    //}
}




