using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tbullet : MonoBehaviour {

    public GameObject bulletPrefab;
    // Use this for initialization
    public GameObject player;
    public float coolDown=2;
    Vector2 myPos;
    Vector2 direction;
    public float speed=1;
    public bool isWork = true;
    Animator anim;
    public int bananaCost = 2;
    void Start () {
        anim = GetComponent<Animator>();
        player = GetComponent<MonkeyController>().gameObject;
    }
	
	// Update is called once per frame
	void Update () {


        if (isWork)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                StartCoroutine(CoolDown());
                isWork = false;
                anim.SetTrigger("teleport");
                
            }
        }

    }
   
    public void FireBullet()
    {
        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x,  Input.mousePosition.y));
        myPos = new Vector2(transform.position.x, transform.position.y + 1);
        direction = target - myPos;
        direction.Normalize();
        
        GameObject bulletInstance = (Instantiate(bulletPrefab, myPos,Quaternion.identity )) as GameObject;
        Vector3 theScale = bulletInstance.transform.localScale;
        theScale.x *=(player.transform.localScale.x/Mathf.Abs(player.transform.localScale.x));
        bulletInstance.transform.localScale = theScale;
        gameObject.GetComponent<MonkeyState>().banana -= bananaCost;
        Rigidbody2D rigid;
        rigid = bulletInstance.GetComponent<Rigidbody2D>();

        rigid.velocity = direction * speed;
        //StopCoroutine("CoolDown");
        
        //coolDown = Time.time + attackSpeed;
    }

   

    IEnumerator CoolDown()
    {
        isWork = false;
        yield return new WaitForSeconds(coolDown);
        isWork = true;
    }
   
}
