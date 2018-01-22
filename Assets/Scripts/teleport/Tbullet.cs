using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tbullet : MonoBehaviour {

    public GameObject bulletPrefab;
    // Use this for initialization
    public int power=2;
    public float coolDown=2;
    public float attackSpeed = 10000.5f;
    Vector2 myPos;
    Vector2 direction;
    int speed=20;
    public bool isWork = true;
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {


        if (isWork)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                FireBullet();
            }
        }

    }
   
    public void FireBullet()
    {
        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x,  Input.mousePosition.y));
        myPos = new Vector2(transform.position.x, transform.position.y + 1);
        direction = target - myPos;
        direction.Normalize();

        GameObject bulletInstance = (Instantiate(bulletPrefab, myPos, Quaternion.identity)) as GameObject;

        Rigidbody2D rigid;
        rigid = bulletInstance.GetComponent<Rigidbody2D>();

        rigid.velocity = direction * speed;
        //StopCoroutine("CoolDown");
        StartCoroutine(CoolDown());
        //coolDown = Time.time + attackSpeed;
    }

    IEnumerator CoolDown()
    {
        isWork = false;
        yield return new WaitForSeconds(coolDown);
        isWork = true;
    }
   
}
