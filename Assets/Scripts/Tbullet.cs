using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tbullet : MonoBehaviour {

    public GameObject bulletPrefab;
    // Use this for initialization
    public int power=2;
    public float coolDown;
    public float attackSpeed = 0.5f;


    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

       
        if (Time.time >= coolDown)
        {
            if (Input.GetMouseButton(1))
            {
                FireBullet();
            }
        }
    }
   
    public void FireBullet()
    {
       

        GameObject bulletInstance = (Instantiate(bulletPrefab, transform.position, transform.rotation)) as GameObject;

        Rigidbody2D rigid;
        rigid = bulletInstance.GetComponent<Rigidbody2D>();

        rigid.velocity = new Vector2(5 * power, 0);

        coolDown = Time.time + attackSpeed;
    }
}
