using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedCollision : MonoBehaviour {
    public GameObject[] TreePrefabs;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("dirt"))
        {
            int index = Random.Range(0, TreePrefabs.Length);
            Vector3 p = TreePrefabs[index].transform.position;
            p.x = collision.transform.position.x;
          GameObject bulletInstance = Instantiate(TreePrefabs[index], p, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;

           
            Destroy(gameObject);
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




